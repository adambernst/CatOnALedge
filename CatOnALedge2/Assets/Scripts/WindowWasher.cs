using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowWasher : MonoBehaviour
{
    public int topLimit = 95;
    public int botLimit = 46;
    
    public float moveRate = 0.5f;
    public float slowRange = 3f;
    
    private bool goingUp = true;
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= topLimit){
            goingUp = false;
        } else if (transform.position.y <= botLimit){
            goingUp = true;
        }
        
        Vector3 deltaY;
        if (goingUp) {
            if (transform.position.y < topLimit - slowRange){
                deltaY = new Vector3(0f, moveRate, 0f);
            } else {
                deltaY = new Vector3(0f, moveRate / 2, 0f);
            }
        } else {
            if (transform.position.y > botLimit + slowRange){
                deltaY = new Vector3(0f, -1 * moveRate, 0f);
            } else {
                deltaY = new Vector3(0f, -1 * moveRate / 2, 0f);
            }
        }
        transform.position += deltaY;
    }
    
    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Player"){
            other.collider.transform.parent = transform;
        }
    }
}
