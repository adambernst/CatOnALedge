using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int index;
    public GameObject respawnTrigger;
    public GameObject checkmark;
    private Respawn resScript;
    
    public GameObject musicPlayer;
    private AudioFX audioFX;
    
    void Start() {
        audioFX = musicPlayer.GetComponent<AudioFX>();
        resScript = respawnTrigger.GetComponent<Respawn>();
    }
    
    //private bool touching = false;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            checkmark.SetActive(true);
            audioFX.PlayCheckpoint();
            
            if (index > resScript.checkIndex) {
                resScript.checkIndex = index;
            }
        }
    }
}
