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

	/* Start is called before the first frame update */
	void Start(){
		player = GetComponent<CharacterController>();
	}

    void Update() {
        Debug.Log(player.transform.eulerAngles.y);
        if ((player.transform.eulerAngles.y > 180 && player.transform.eulerAngles.y > 360)) { // player is facing backwards 
            if (playerCollider.IsTouching("CamSwitchRightCamTrigger") {
                CamMode = 1;
            } else {
                CamMode = 0;
            }
        }

        if ((player.transform.eulerAngles.y > 0 && player.transform.eulerAngles.y > 180) ) { // player is facing forwards 
            if (playerCollider.IsTouching("CamSwitchRightCamTrigger") {
                CamMode = 0;
            } else {
                CamMode = 1;
            }
        }
        StartCoroutine (CamChange()); 
    }

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



//when cat facing backwards, switch camera from current state to opposite state
//when cat faces forward again, switch camera from current state to opposite state 
