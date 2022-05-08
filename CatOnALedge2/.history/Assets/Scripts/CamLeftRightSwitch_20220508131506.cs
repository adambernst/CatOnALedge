using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLeftRightSwitch : MonoBehaviour
{  
    public GameObject BackCameraRight;
    public GameObject BackCameraLeft; 
    public int CamMode; 

    void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.name =="CamSwitchRightCamTrigger") {
            CamMode = 0;
        }
        if (other.gameObject.name == "CamSwitchLeftCamTrigger") {
            CamMode = 1; 
        }
        // if (CamMode == 1) {
        //     CamMode = 0;
        // } else {
        //     CamMode += 1; 
        // }
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
