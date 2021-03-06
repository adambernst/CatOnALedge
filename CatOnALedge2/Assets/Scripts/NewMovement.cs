using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;

[RequireComponent(typeof(CharacterController))]
public class NewMovement : MonoBehaviour{
    [HideInInspector]
    public CharacterController mCharacterController;
    public Animator Anim;
    public Vector3 direction;

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
	public float superFall = -100f;
    /////////////////////

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public GameObject musicPlayer;
    private AudioFX audioFX;

	/* Start is called before the first frame update */
	void Start(){
		mCharacterController = GetComponent<CharacterController>();
		Anim = GetComponentInChildren<Animator>();
		audioFX = musicPlayer.GetComponent<AudioFX>();
	}

	void Update(){
		// Jump();
		Move();   
	}


	/*
		Function: Move()
		Purpose: movement controls for character
	*/ 
	public void Move(){
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		float speed = mWalkSpeed;

		/* run if left shift key is down */ 
		if (Input.GetKey(KeyCode.LeftShift)){
			speed = mRunSpeed;
		}

		mCharacterController.Move(transform.forward * v * speed * Time.deltaTime);
		transform.Rotate(0.0f, h * mRotationSpeed * Time.deltaTime, 0.0f);
    
		direction = new Vector3(h, 0f, v).normalized;
		// if (direction != Vector3.zero)
		// {
		//     Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
		//     transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, mRotationSpeed * Time.deltaTime);
		// }

        // if (direction.magnitude >= 0.1f)
        // {       
        //     float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        //     float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //     transform.rotation = Quaternion.Euler(0f, angle, 0f);

        //     Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //     mCharacterController.Move(moveDir.normalized * speed * Time.deltaTime);
        //     // controller.Move(cam.transform.forward * speed * Time.deltaTime);
        // }

		/* apply gravity */
		mVelocity.y += mGravity * Time.deltaTime;
		mCharacterController.Move(mVelocity * Time.deltaTime);

		if (mCharacterController.isGrounded && mVelocity.y < 0){
			mVelocity.y = 0f;
		}

		/* apply animation rules */
		//if(direction.magnitude >= 0.1f) {
		if ((h==0)&&(v==0)){
			//Anim.SetBool("Idle", false);
			Anim.SetBool("Walk", false);
		}else {
			Anim.SetBool("Walk", true);
			//Anim.SetBool("Idle", true);       
		}
		//if (Anim != null){   Anim.SetFloat("PosZ", v * speed / mRunSpeed);}

        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // if (isGrounded && velocity.y < 0)
        // {
        //     velocity.y = -2f;
        //     // velocity += Vector3.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        // }

        if (mVelocity.y < 0){
            mVelocity.y += mGravity * (fallMultiplier - 1) * Time.deltaTime;
        }

        // if ((Input.GetButtonDown("Jump") && isGrounded) || (mVelocity.y <= superFall)){
        if (Input.GetButtonDown("Jump") && isGrounded){
            audioFX.PlayMeow1();
            mVelocity.y = Mathf.Sqrt(jumpHeight * -2 * mGravity);
            Anim.SetTrigger("Jump");
            //Anim.SetBool("Walk", false);
            //Anim.SetBool("Idle", false);
        }
		
        if (mVelocity.y > 0 && !Input.GetButtonDown("Jump")){
            mVelocity.y += mGravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        
  } /* end of Move() function */


  /*
   * Function: Jump()
   * Purpose: Jump controls for character
   */ 
  public void Jump(){
        //jump
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // if (isGrounded && velocity.y < 0)
        // {
        //     velocity.y = -2f;
        //     // velocity += Vector3.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        // }

        // if (mVelocity.y < 0)
        // {
            // mVelocity.y += mGravity * (fallMultiplier - 1) * Time.deltaTime;
        // }

        // if (Input.GetButtonDown("Jump") && isGrounded)
        // {
            // audioFX.PlayMeow1();
            // mVelocity.y = Mathf.Sqrt(jumpHeight * -2 * mGravity);
            // Anim.SetTrigger("Jump");
            //Anim.SetBool("Walk", false);
            //Anim.SetBool("Idle", false);
        // }
        // if (mVelocity.y > 0 && !Input.GetButtonDown("Jump"))
        // {
            // mVelocity.y += mGravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        // }
        
        // void OnCollisionEnter(Collision other) {
          // if (other.gameObject.tag == "Ground") {
            // audioFX.PlayThud();
          // }
        // }
  } /* end of Jump() function */

}