
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : EntityComponent<Character> {

	private Rigidbody rb;
	private Animator anim;
	public float speed;
	public float maxSpeed;
	public float rotSpeed;

	private bool isJumping;
	private bool canJump;
	public float jumpIntensity = 5;
	public float raycastLenght= 1;
	public LayerMask jumpDetection;
	

	protected override void Awake() {
		base.Awake();
		rb = GetComponent<Rigidbody>();
	}

	private void Update() {
		ManageJump();
	}

	private void ManageJump() {

		// if (Entity.currentPhase != Character.CharPhase.One) {
			if (Entity.player.GetButtonDown("Jump") && IsGrounded()) {
				Debug.Log("Jump");
				rb.AddForce(Vector3.up * (jumpIntensity*10 * Time.fixedDeltaTime),ForceMode.Impulse);
			}
		// }
	}

	private void FixedUpdate() {
		ManageRotation();
		ManageMovement();
	}

	private void ManageMovement() {
		var z = Entity.player.GetAxis("MoveV");
		if (z > 0 && IsGrounded()) {
			if (rb.velocity.magnitude < maxSpeed) {
				rb.velocity += transform.forward * (z * (speed * Time.fixedDeltaTime));
				rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
			}
		}
		if (z == 0 && IsGrounded()) {
			rb.velocity = Vector3.zero;
		}
	}

	private void ManageRotation() {
		var x = Entity.player.GetAxis("MoveH");
		transform.Rotate(Vector3.up, x * rotSpeed);
	}

	private void OnDrawGizmosSelected() {
		Gizmos.color= Color.magenta;
		Gizmos.DrawCube(transform.position , Vector3.one/9);
	}

	private bool IsGrounded() {
		var hit = Physics.OverlapBox(transform.position, Vector3.one/9, Quaternion.identity,jumpDetection);
		Debug.Log(hit);
		if (hit.Length>0) {
			return true;
		}
		return false;
	}
}