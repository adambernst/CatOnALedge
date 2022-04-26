using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCameraFollow : MonoBehaviour {

    // public GameObject player;
    // public float cameraDistance = 10.0f;

    // // Use this for initialization
    // void Start () {
    // }

    // void Update ()
    // {
    //     transform.position = player.transform.position - player.transform.forward * cameraDistance;
    //     transform.LookAt (player.transform.position);
    //     transform.position = new Vector3 (transform.position.x, transform.position.y + 5, transform.position.z);
    // }

     public float cameraDistOffset = 10;
     private Camera mainCamera;
     private GameObject player;
 
     // Use this for initialization
     void Start () {
         mainCamera = GetComponent<Camera>();
         player = GameObject.Find("Player");
     }
     
     // Update is called once per frame
     void Update () {
         Vector3 playerInfo = player.transform.transform.position;
         mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z - cameraDistOffset);
     }


}