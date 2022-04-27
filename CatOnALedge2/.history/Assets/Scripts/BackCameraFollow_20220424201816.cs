using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCameraFollow : MonoBehaviour {

    public GameObject player;
    public float cameraDistance = 10.0f;

    // Use this for initialization
    void Start () {
    }

    void Update ()
    {
        // transform.position = player.transform.position - player.transform.forward * cameraDistance;
        // transform.LookAt (player.transform.position);
        // transform.position = new Vector3 (transform.position.x, transform.position.y + 5, transform.position.z);



        transform.position = player.transform.position * cameraDistance;
        transform.LookAt (player.transform.position);
        transform.position = new Vector3 (transform.position.x, transform.position.y + 5, transform.position.z);

    }




    // public Transform target;
    // public Vector3 offset;

    // void Update()
    // {
    //     transform.position = target.position + offset; 
    // }

}