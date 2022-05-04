using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBed : MonoBehaviour
{
    public GameObject cat;
    
    private void OnTriggerEnter(Collider other){
    //private void OnCollisionEnter(Collision other){
        Debug.Log("Collision: " + other.gameObject.tag);
        if(other.gameObject.tag == "kitten"){
            other.GetComponent<KittenManager>().isHome = true;
            PickUpObject script = cat.GetComponent<PickUpObject>();
            script.rescueKitten();
        }
    }
}
