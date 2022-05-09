using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLeftRightSwitch : MonoBehaviour
{  
    public GameObject BackCameraRight;
    public GameObject BackCameraLeft; 
    public int CamMode; 
    public CharacterController player;
    public Collider playerCollider;
    public Collider rightCamTrigger;
    public Collider leftCamTrigger; 

	/* Start is called before the first frame update */
	void Start(){
		player = GetComponent<CharacterController>();
	}

    // void LateUpdate() {
    //     // Debug.Log(player.transform.eulerAngles.y);
    //     if ((player.transform.eulerAngles.y > 180 && player.transform.eulerAngles.y < 360)) { // player is facing backwards (relative to world)
    //         if (playerCollider.bounds.Intersects(rightCamTrigger.bounds)) {
    //             CamMode = 1;
    //         } 
    //         if (playerCollider.bounds.Intersects(leftCamTrigger.bounds)) {
    //             CamMode = 0;
    //         } 
    //     }

    //     if ((player.transform.eulerAngles.y > 0 && player.transform.eulerAngles.y < 180) ) { // player is facing forwards (relative to world)
    //         if (playerCollider.bounds.Intersects(rightCamTrigger.bounds)) {
    //             CamMode = 0;
    //         } 
    //         if (playerCollider.bounds.Intersects(leftCamTrigger.bounds)) {
    //             CamMode = 1;
    //         } 
    //     }
    //     StartCoroutine (CamChange()); 
    // }

    void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.name =="CamSwitchRightCamTrigger") {
            if ((player.transform.eulerAngles.y > 180 && player.transform.eulerAngles.y > 360)) {
                CamMode = 1; 
            } else {
                CamMode = 0;
            }
        }
        if (other.gameObject.name == "CamSwitchLeftCamTrigger") {
            if ((player.transform.eulerAngles.y > 180 && player.transform.eulerAngles.y > 360)) {
                CamMode = 0;
            } else {
                CamMode = 1;
            } 
        }
        StartCoroutine (CamChange());     
    }
    

    IEnumerator CamChange() {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0) { // set active cam as right cam
            BackCameraRight.SetActive(true);
            BackCameraLeft.SetActive(false);
        }
        if  (CamMode == 1) { // set active cam as left cam
            BackCameraRight.SetActive(false);
            BackCameraLeft.SetActive(true);
        }
    }

}