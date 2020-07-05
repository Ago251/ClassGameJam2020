using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    private Player player;
    public float mouseSensitivity;

    public Transform playerBody;
    private float xRot=0;

    private void Awake() {
        player = ReInput.players.GetPlayer(0);
    }

    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        float mouseX = player.GetAxis("MouseH") * mouseSensitivity * Time.deltaTime;
        float mouseY = player.GetAxis("MouseV") * mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);
        
        transform.localRotation=Quaternion.Euler(xRot,0,0);
        playerBody.transform.Rotate(Vector3.up * mouseX);
    }
}
