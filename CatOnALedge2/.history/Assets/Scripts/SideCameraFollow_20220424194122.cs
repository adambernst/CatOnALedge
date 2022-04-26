using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCameraFollow : MonoBehaviour {



  

    void LateUpdate ()
    {
        camera.transform.localPosition = new Vector3(-camera.transform.localPosition.x, camera.transform.localPosition.y, -camera.transform.localPosition.z);    
        camera.transform.LookAt(camera.transform.parent.position);
    }




    // public Transform target;
    // public Vector3 offset;

    // void Update()
    // {
    //     transform.position = target.position + offset; 
    // }

}