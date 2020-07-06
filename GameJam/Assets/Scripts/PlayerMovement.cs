using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Player player;
    private CharacterController controller;

    public bool canJump;
    public float speed = 10;

    public Transform groundCheck;
    public LayerMask groundMask;
    private bool isGrounded;
    private Vector3 vel;
    public float jumpH = 3f;
    
    private void Awake() {
        player = ReInput.players.GetPlayer(0);
        controller = GetComponent<CharacterController>();
    }
    
    // Update is called once per frame
    void Update() {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);

        if (isGrounded && vel.y < 0) {
            vel.y = -2f;
        }
        float x = player.GetAxis("MoveH");
        float z = player.GetAxis("MoveV");

        Vector3 move = transform.right * x + transform.forward * z; 
        controller.Move(move * (speed * Time.deltaTime));
        
        if (canJump && player.GetButtonDown("Jump") && isGrounded) {
            vel.y = Mathf.Sqrt(jumpH * -2f * -9.81f);
        }
        vel.y -= 9.81f * Time.deltaTime;
        controller.Move(vel * Time.deltaTime);
    }
    
    
}
