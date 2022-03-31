using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

     public float speed;
     public float rotSpeed;
     public float JumpHeight;
     public bool isGrounded;
     public float GravityStrength;
     Rigidbody rb;
     
     void Start() {
         Vector3 gravityS = new Vector3(0, GravityStrength, 0);
         
         Physics.gravity = gravityS;
         rb = GetComponent<Rigidbody>();
         isGrounded = true;
     }
     
     void Update() {
         var z = Input.GetAxis("Vertical") * speed;
         var y = Input.GetAxis("Horizontal") * rotSpeed;
         
         transform.Translate(0, 0, z);
         transform.Rotate(0, y, 0);
         
         if (Input.GetKey(KeyCode.Space) && isGrounded == true) {
             Jump();
         }
     }
     
     void Jump() {
         rb.AddForce(new Vector3(0, JumpHeight, 0));
         isGrounded = false;
         // Animation goes here
     }
     
     void OnCollisionEnter(Collision other) {
         // if (other.collisionInfo.Collider.tag == "Ground")
            isGrounded = true;
     }
}