using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCameraFollow : MonoBehaviour {

    // Use this for initialization
    void Start () {
    }

    void LateUpdate ()
    {
        // GetComponent<Camera>().transform.localPosition = new Vector3(-GetComponent<Camera>().transform.localPosition.x, GetComponent<Camera>().transform.localPosition.y, -GetComponent<Camera>().transform.localPosition.z);    
        // GetComponent<Camera>().transform.LookAt(GetComponent<Camera>().transform.parent.position);

 camera.transform.localPosition = -camera.transform.localPosition; // move the camera to the opposite side of the player. Assuming camera is child of player.
 camera.transform.LookAt(camrea.transform.parent.position); // turn the camera so that it faces the player
    }




    // public Transform target;
    // public Vector3 offset;

    // void Update()
    // {
    //     transform.position = target.position + offset; 
    // }

}