using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SYJump : MonoBehaviour {

    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float gravityScale = 1f;
    [SerializeField]
    private float jumpTimer = 0.5f;


    private bool pressedJump = false;
    private bool releasedJump = false;

    private bool startTimer = false;
    private float timer;


    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();

        timer = jumpTimer;
    }

    private void Update() {
        if (Input.GetButtonDown("Jump")) {
            pressedJump = true;
        }

        if (Input.GetButtonUp("Jump")) {
            releasedJump = true;
        }

        if (startTimer) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                releasedJump = true;
            }
        }
    }

    private void FixedUpdate() {
        if (pressedJump) {
            StartJump();
        }

        if (releasedJump) {
            StopJump();
        }
    }


    private void StartJump() {
        rb.gravityScale = 0;
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        pressedJump = false;
        startTimer = true;
    }

    private void StopJump() {
        rb.gravityScale = gravityScale;
        releasedJump = false;
        timer = jumpTimer;
        startTimer = false;
    }
}
