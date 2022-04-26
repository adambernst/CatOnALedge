using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCameraFollow : MonoBehaviour {

    // public GameObject player;
    public GameObject target;
    public float cameraDistance = 10.0f;
    Vector3 offset;

    // Use this for initialization
    void Start () {
        offset = target.transform.position - transform.position;
    }

    // void Update ()
    // {
    //     transform.position = player.transform.position - player.transform.forward * cameraDistance;
    //     transform.LookAt (player.transform.position);
    //     transform.position = new Vector3 (transform.position.x, transform.position.y + 5, transform.position.z);
    // }

    void LateUpdate ()
    {
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);

        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }
}
