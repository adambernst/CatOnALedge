using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittenManager : MonoBehaviour
{
    public bool isHome;
    
    void Start(){
        isHome = false;
    }
    
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "kittenBed"){
            isHome = true;
            Debug.Log("YEEE HAW");
        }
    }
}
