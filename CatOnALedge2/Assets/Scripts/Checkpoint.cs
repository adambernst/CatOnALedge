using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int index;
    public GameObject respawnTrigger;
    private Respawn resScript;
    private bool touching = false;
    

    void OnTriggerEnter(Collider other)
    {
        if (!touching){
            touching = true;
            resScript = respawnTrigger.GetComponent<Respawn>();
            if (index > resScript.checkIndex) {
                resScript.checkIndex = index;
            }
        }
    }
}
