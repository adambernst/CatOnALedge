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
  public Animator mAnimator;

  public float mWalkSpeed = 1.5f;
  public float mRunSpeed = 3.0f;
  public float mRotationSpeed = 50.0f;
  public float mGravity = -30.0f;
  private Vector3 mVelocity = new Vector3(0.0f, 0.0f, 0.0f);

  // Start is called before the first frame update
  void Start()
  {
    mCharacterController = GetComponent<CharacterController>();
    mAnimator = GetComponentInChildren<Animator>();
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
    if (mAnimator != null)
    {
    //   mAnimator.SetFloat("PosZ", v * speed / mRunSpeed);
    }

    // apply gravity.
    mVelocity.y += mGravity * Time.deltaTime;
    mCharacterController.Move(mVelocity * Time.deltaTime);

    if (mCharacterController.isGrounded && mVelocity.y < 0)
      mVelocity.y = 0f;

    if (GetComponent<Rigidbody>().velocity.magnitude >= 0) {
            mAnimator.SetBool("Idle", false);
            mAnimator.SetBool("Walk", true);
    }
    else {
            mAnimator.SetBool("Walk", false);
            mAnimator.SetBool("Idle", true);  
    }
  } // end of move function

}