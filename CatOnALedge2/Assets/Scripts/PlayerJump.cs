using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

      //public Animator animator;
      public Rigidbody rb;
      public float jumpForce = 20f;
      public Transform feet;
      public LayerMask groundLayer;
      public LayerMask enemyLayer;
      public bool isAlive = true;
      //public AudioSource JumpSFX;

      void Start(){
            //animator = gameObject.GetComponentInChildren<Animator>();
            rb = GetComponent<Rigidbody>();
      }

     void Update() {
           if ((Input.GetButtonDown("Jump")) // && (IsGrounded()) 
           && (isAlive==true)) {
                  Jump();
               // animator.SetTrigger("Jump");
               // JumpSFX.Play();
            }
      }

      public void Jump() {
            rb.velocity = Vector3.up * jumpForce;
            //Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
            //rb.velocity = movement;
      }

      // public bool IsGrounded() {
      //       // Collider groundCheck = Physics.OverlapCircle(feet.position, 2f, groundLayer);
      //       // Collider enemyCheck = Physics.OverlapCircle(feet.position, 2f, enemyLayer);
      //      if ((groundCheck != null) || (enemyCheck != null)) {
      //             return true;
      //             //Debug.Log("I can jump now!");
      //       }
      //       return false;
      // }
}