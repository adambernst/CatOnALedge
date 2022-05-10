using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    public AudioSource meow1;
    public AudioSource checkpoint;
    public AudioSource lostLife;
    public AudioSource kitten_meow1;
    public AudioSource whoosh;
    
    public void PlayMeow1() {
        meow1.Play();
    }
    
    public void PlayCheckpoint() {
        checkpoint.Play();
    }
    
    public void PlayLostLife() {
        lostLife.Play();
    }

    public void PlayKittenMeow1() {
        kitten_meow1.Play();
    }

    
    
    
    
    
    
}
