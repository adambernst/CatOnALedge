using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPMove2 : MonoBehaviour
{
	public CharacterController controller;
    public Transform cam;
    
    private Vector3 jumpVel;
    private bool groundedPlayer;
    
    public float speed = 6f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    
    void Update()
    {
        
        if (controller.isGrounded) {
            Debug.Log("On da ground");
        } else {
            Debug.Log("Naw");
        }
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && jumpVel.y < 0)
        {
            jumpVel.y = 0f;
        }
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        if (direction.magnitude >= 0.1f)
        {
            // sets angle to the way character is facing
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            jumpVel.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        jumpVel.y += gravityValue * Time.deltaTime;
        controller.Move(jumpVel * Time.deltaTime);
    }
} 