using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCameraFollow : MonoBehaviour {

    public GameObject player;
    // public GameObject target;
    public float cameraDistance = 10.0f;
    // Vector3 offset;
    // public float multiplier = 1.1f;
    public Transform player1;
    public GameObject cam; 

    // Use this for initialization
    void Start () {
        // offset = target.transform.position - transform.position;
    }

    void Update ()
    {
            // float Rotation;
            // if(player1.eulerAngles.x <= 180f)
            // {
            //     Rotation = player1.eulerAngles.x;
            // }
            // else
            // {
            //     Rotation = player1.eulerAngles.x - 360f;
            // }

            // transform.position = player.transform.position - player.transform.forward * cameraDistance;
            // transform.LookAt(player.transform.position);
            // transform.position = new Vector3 (transform.position.x, transform.position.y + 3, transform.position.z);


            // GetComponent<Camera>().transform.localPosition = -GetComponent<Camera>().transform.localPosition; // move the camera to the opposite side of the player. Assuming camera is child of player.
            // GetComponent<Camera>().transform.LookAt(GetComponent<Camera>().transform.parent.position); // turn the camera so that it faces the player



            // float Rotation;
            // if(player1.eulerAngles.y < 0f)
            // {
            //     cam.transform.localPosition = -cam.transform.localPosition; // move the camera to the opposite side of the player. Assuming camera is child of player.
            //         // GetComponent<Camera>().transform.LookAt(GetComponent<Camera>().transform.parent.position); // turn the camera so that it faces the player
            // }
            // if(player1.eulerAngles.y > 180f)
            // {
            //     cam.transform.localPosition = -cam.transform.localPosition; // move the camera to the opposite side of the player. Assuming camera is child of player.
            // }

            



            // transform.position = player.transform.position - player.transform.forward * cameraDistance;
            // transform.LookAt(player.transform.position);
            // transform.position = new Vector3 (transform.position.x, transform.position.y + 3, transform.position.z);



    }

}