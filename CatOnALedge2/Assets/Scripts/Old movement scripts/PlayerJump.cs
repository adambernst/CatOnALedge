using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerJump : MonoBehaviour {
    
    // private CharacterController characterController;

    // public float speed;
    // public float rotSpeed;
    public float jumpHeight;
    // public Vector3 velocity;
    private bool isGrounded;
    // private bool jumpPressed = false;
    // public float gravityStrength = -9.81;
    Rigidbody rb;
     // 
     void Start() {
         // characterController = GetComponent<CharacterController>();
         
         
         // Vector3 gravityS = new Vector3(0, GravityStrength, 0);
         // 
         // Physics.gravity = gravityS;
         rb = GetComponent<Rigidbody>();
         // isGrounded = true;
     }
     
     void Update() {
         if (Input.GetButtonDown("Jump") && isGrounded) {
             Jump();
         }
         
            
     //     var z = Input.GetAxis("Vertical") * speed;
     //     var y = Input.GetAxis("Horizontal") * rotSpeed;
     // 
     //     transform.Translate(0, 0, z);
     //     transform.Rotate(0, y, 0);
     // 
     //     if (Input.GetKey(KeyCode.Space) && isGrounded == true) {
     //         Jump();
        // }
    }
    
     // 
     void Jump() {
         Debug.Log("Jump pressed");
         
         
         
         
         rb.AddForce(new Vector3(0, jumpHeight, 0));
         isGrounded = false;
         // Animation goes here
     }
     
     void OnCollisionStay(Collision other) {
         // if (other.collisionInfo.Collider.tag == "Ground")
            isGrounded = true;
     }
}