using System.Collections;


using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class SeoyunThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public Animator Anim;


    void Start()
    {
        Anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame

    void Update()
    {
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            // velocity += Vector3.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (velocity.y < 0)
        {
            velocity.y += gravity * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            Anim.SetTrigger("Jump");
            Anim.SetBool("Walk", false);
            Anim.SetBool("Idle", false);
        }
        if (velocity.y > 0 && !Input.GetButtonDown("Jump"))
        {
            velocity.y += gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }




        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //walk
        float horizontal = Input.GetAxisRaw("Vertical");
        float vertical = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0f, -vertical).normalized;
        

        if (direction.magnitude >= 0.1f)
        {

             camera.transform.localPosition = new Vector3(-camera.transform.localPosition.x, camera.transform.localPosition.y, -camera.transform.localPosition.z);    
             camera.transform.LookAt(camera.transform.parent.position);

             
            Anim.SetBool("Idle", false);
            Anim.SetBool("Walk", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        
        
        }
        else
        {
            Anim.SetBool("Walk", false);
            Anim.SetBool("Idle", true);
        }
       

    }
}