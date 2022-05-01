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
    Vector3 velocity;
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpHeight = 3;
    /////////////////////

    public AudioFX audioFX;

  // Start is called before the first frame update
  void Start()
  {
    mCharacterController = GetComponent<CharacterController>();
    Anim = GetComponentInChildren<Animator>();
  }

  void Update()
  {
    Move();
  }

  public void Move()
  {
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    float speed = mWalkSpeed;
    // run if left shift key is down
    if (Input.GetKey(KeyCode.LeftShift))
    {
      speed = mRunSpeed;
    }

    mCharacterController.Move(transform.forward * v * speed * Time.deltaTime);
    transform.Rotate(0.0f, h * mRotationSpeed * Time.deltaTime, 0.0f);
    if (Anim != null)
    {
    //   Anim.SetFloat("PosZ", v * speed / mRunSpeed);
    }

    // apply gravity.
    mVelocity.y += mGravity * Time.deltaTime;
    mCharacterController.Move(mVelocity * Time.deltaTime);

    if (mCharacterController.isGrounded && mVelocity.y < 0)
      mVelocity.y = 0f;

    // apply animation rules 
    if (GetComponent<Rigidbody>().velocity.magnitude >= 0.1f) {
            Anim.SetBool("Idle", false);
            Anim.SetBool("Walk", true);
    }
    else {
            Anim.SetBool("Walk", false);
            Anim.SetBool("Idle", true);  
    }
  } // end of Move() function


  public void Jump()
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
            velocity.y += mGravity * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            audioFX.PlayMeow1();
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * mGravity);
            Anim.SetTrigger("Jump");
            Anim.SetBool("Walk", false);
            Anim.SetBool("Idle", false);
        }
        if (velocity.y > 0 && !Input.GetButtonDown("Jump"))
        {
            velocity.y += mGravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
  }

}