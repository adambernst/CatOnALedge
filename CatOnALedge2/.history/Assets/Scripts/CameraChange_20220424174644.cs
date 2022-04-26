using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject BackCamera;
    public GameObject SideCamera;
    public int CamMode; 

    void Update () {
        if  (Input.GetButtonDown("Camera")) {
            if (CamMode == 1) {
                CamMode = 0;
            } else {
                CamMode += 1; 
            }
            StartCoroutine (CamChange());
        }
    }


    IEnumerator CamChange() {
        yield return now WaitForSeconds(0.01f);
        if (CamMode == 0) {
            BackCamera.SetActive(true);
            FirstCamera.SetActive(false);
        }
        if  (CamMode == 1) {
            BackCamera.SetActive(false);
            FirstCamera.SetActive(true);
        }
    }

}