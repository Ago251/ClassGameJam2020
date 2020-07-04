
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class CharacterMovement : EntityComponent<Character> {

	private Rigidbody rb;
	private Animator animator;
	public float speed;
	public float rotSpeed;

	private bool isJumping;
	private bool canJump;
	public float jumpIntensity = 5;
	public float raycastLenght= 1;
	public LayerMask jumpDetection;
	public bool IsJumping {
		get => isJumping;
		set {
			isJumping = value;
			animator.SetBool("isJumping",value);
		}
	}

	protected override void Awake() {
		base.Awake();
		rb = GetComponent<Rigidbody>();
	}

	private void Update() {
		ManageJump();
	}

	private void ManageJump() {

		canJump = Physics.Raycast(transform.position, Vector3.down,raycastLenght,jumpDetection);
		Debug.Log(canJump);

		// if (Entity.currentPhase != Character.CharPhase.One) {
			if (Entity.player.GetButtonDown("Jump")) {
				if (canJump) {
					IsJumping = true;
					rb.AddForce(Vector3.up * jumpIntensity,ForceMode.Impulse);
				}
			}
		// }
	}

	private void FixedUpdate() {
		ManageMovement();
		ManageRotation();
	}

	private void ManageMovement() {
		var z = Entity.player.GetAxis("MoveV");
		z = Mathf.Clamp(z, 0, 100000);
		rb.velocity = transform.forward * (speed * z);
	}

	private void ManageRotation() {
		var x = Entity.player.GetAxis("MoveH");
		transform.Rotate(Vector3.up, x * rotSpeed);
	}

	private void OnDrawGizmosSelected() {
		Gizmos.color= Color.magenta;
		Gizmos.DrawRay(transform.position , Vector3.down);
	}
}