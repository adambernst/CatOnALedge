using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int index;
    public GameObject respawnTrigger;
    private Respawn resScript;
    
    public void OnCollisionEnter(Collision cat) {
        if (cat.gameObject.tag == "Player"){
            resScript = respawnTrigger.GetComponent<Respawn>();
            if (index > resScript.checkIndex) {
                resScript.checkIndex = index;
            }
        }
    }
}
