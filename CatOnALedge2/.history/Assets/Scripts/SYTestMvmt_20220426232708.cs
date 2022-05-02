using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;

[RequireComponent(typeof(CharacterController))]
public class SYTestMvmt : MonoBehaviour
{
    [HideInInspector]
    public CharacterController mCharacterController;
    public Animator Anim;

    public float mWalkSpeed = 1.5f;
    public float mRunSpeed = 3.0f;
    public float mRotationSpeed = 50.0f;
    public float mGravity = -30.0f;
    private Vector3 mVelocity = new Vector3(0.0f, 0.0f, 0.0f);

    //////////////////////
    // Vector3 velocity;
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpHeight = 3;
    /////////////////////

    public AudioFX audioFX;

  /* Start is called before the first frame update */
  void Start()
  {
    mCharacterController = GetComponent<CharacterController>();
    Anim = GetComponentInChildren<Animator>();
  }

  void Update()
  {
    Jump();
    Move();   
  }

  public void Move()
  {
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");
    float speed = mWalkSpeed;

    if (Input.GetKey(KeyCode.LeftShift)) /* run if left shift key is down */ 
    {
      speed = mRunSpeed;
    }

    mCharacterController.Move(transform.forward * v * speed * Time.deltaTime);
    transform.Rotate(0.0f, h * mRotationSpeed * Time.deltaTime, 0.0f);
    
    Vector3 direction = new Vector3(h, 0f, v);


    /* apply gravity */
    mVelocity.y += mGravity * Time.deltaTime;
    mCharacterController.Move(mVelocity * Time.deltaTime);

    if (mCharacterController.isGrounded && mVelocity.y < 0) 
    {
        mVelocity.y = 0f;
    }

    /* apply animation rules */
    if(direction.magnitude >= 0.1f) 
    {
        Anim.SetBool("Idle", false);
        Anim.SetBool("Walk", true);
    }
    else 
    {
        Anim.SetBool("Walk", false);
        Anim.SetBool("Idle", true);       
    }
    if (Anim != null)
    {
    //   Anim.SetFloat("PosZ", v * speed / mRunSpeed);
    }
  } /* end of Move() function */


  public void Jump()
  {
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // if (isGrounded && velocity.y < 0)
        // {
        //     velocity.y = -2f;
        //     // velocity += Vector3.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        // }

        if (mVelocity.y < 0)
        {
            mVelocity.y += mGravity * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // audioFX.PlayMeow1();
            mVelocity.y = Mathf.Sqrt(jumpHeight * -2 * mGravity);
            Anim.SetTrigger("Jump");
            Anim.SetBool("Walk", false);
            Anim.SetBool("Idle", false);
        }
        if (mVelocity.y > 0 && !Input.GetButtonDown("Jump"))
        {
            mVelocity.y += mGravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
  } /* end of Jump() function */

}