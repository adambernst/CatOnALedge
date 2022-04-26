using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCameraFollow : MonoBehaviour {

    public GameObject player;
    // public GameObject target;
    public float cameraDistance = 10.0f;
    public float rotation;
    // Vector3 offset;
    // public float multiplier = 1.1f;

    // Use this for initialization
    void Start () {
        // offset = target.transform.position - transform.position;
    }

    void Update ()
    {
            rotation = player.transform.rotation;
            transform.position = player.transform.position - player.transform.forward * cameraDistance;
            transform.LookAt(player.transform.position);
            transform.position = new Vector3 (transform.position.x, transform.position.y + 3, transform.position.z);
    }

}