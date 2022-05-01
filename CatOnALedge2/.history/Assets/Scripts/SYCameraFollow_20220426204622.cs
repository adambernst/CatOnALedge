using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SYCameraFollow : MonoBehaviour
{
  public enum ThirdPersonCameraType
  {
    Track,
    Follow,
  }
  public ThirdPersonCameraType mThirdPersonCameraType = 
    ThirdPersonCameraType.Track;
  public Transform mPlayer;
  public float mPlayerHeight = 2.0f;

  public Vector3 mPositionOffset = new Vector3(0.0f, 2.0f, -2.5f);
  public Vector3 mAngleOffset = new Vector3(0.0f, 0.0f, 0.0f);
  [Tooltip("The damping factor to smooth the changes " +
    "in position and rotation of the camera.")]
  public float mDamping = 1.0f;

  void Start()
  {
  }

  void Update()
  {
  }

  void LateUpdate()
  {
    switch (mThirdPersonCameraType)
    {
      case ThirdPersonCameraType.Track:
        {
          CameraMove_Track();
          break;
        }
      case ThirdPersonCameraType.Follow:
        {
          CameraMove_Follow();
          break;
        }
    }
  }

  void CameraMove_Track()
  {
    Vector3 targetPos = mPlayer.transform.position;
    targetPos.y += mPlayerHeight;
    transform.LookAt(targetPos);
  }

  // Follow camera implementation.
  void CameraMove_Follow()
  {
    // We apply the initial rotation to the camera.
    Quaternion initialRotation = 
      Quaternion.Euler(mAngleOffset);
    transform.rotation = Quaternion.RotateTowards(
      transform.rotation, 
      initialRotation, 
      mDamping * Time.deltaTime);

    // Now we calculate the camera transformed axes.
    Vector3 forward = transform.rotation * Vector3.forward;
    Vector3 right = transform.rotation * Vector3.right;
    Vector3 up = transform.rotation * Vector3.up;

    // We then calculate the offset in the 
    // camera's coordinate frame.
    Vector3 targetPos = mPlayer.position;
    Vector3 desiredPosition = targetPos
        + forward * mPositionOffset.z
        + right * mPositionOffset.x + 10
        + up * mPositionOffset.y;

    // Finally, we change the position of the camera, 
    // not directly, but by applying Lerp.
    Vector3 position = Vector3.Lerp(
      transform.position, 
      desiredPosition, 
      Time.deltaTime * mDamping);
    transform.position = position;
  }
}