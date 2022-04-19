using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittenManager : MonoBehaviour
{
    public bool isHome = false; 
    
    //void Start(){
    //   isHome = false;
    //}
    /*
    private void OnTriggerEnter(Collider other){
    //private void OnCollisionEnter(Collision other){
        Debug.Log("Collision: " + other.gameObject.tag);
        if(other.gameObject.tag == "kittenBed"){
            //other.GetComponent<KittenManager>().isHome = true;
            isHome = true;
        }
    }
    */
    public void setHome(){
        isHome = true;
    }
}
