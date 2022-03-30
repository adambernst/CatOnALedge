using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]

public class PlayerJump : MonoBehaviour {
    
    public float jumpForce = 2.0f;
    public float fallMultiplier = 2.5f;
    public Vector3 jump;
    
    public bool isGrounded;
    
    Rigidbody rb;
    
    void Awake() {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    
    private void OnCollisionStay(Collision other){
        if (other.collider.CompareTag("Ground"))
            isGrounded = true;
    }
    
    void Update() {
        // if (rb.velocity.y < 0) {
        if (!isGrounded) {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        // else if (rb.velocity.y > 0 && (Input.GetButton("Jump"))) 
        else if (isGrounded && (Input.GetButton("Jump"))) {
            // rb.velocity += Vector3.up * Physics.gravity.y * (jumpForce - 1) * Time.deltaTime;
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
        
    }
}