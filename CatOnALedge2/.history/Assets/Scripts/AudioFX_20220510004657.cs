using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    public AudioSource thud;
    public AudioSource meow1;
    public AudioSource meow2;
    public AudioSource meow3;
    public AudioSource kitten_meow1;
    
    public void PlayThud() {
        thud.Play();
    }
    
    public void PlayMeow1() {
        meow1.Play();
    }

    public void PlayKittenMeow1() {
        kitten_meow1.Play();
    }

    public void PlayWhoosh() {
        whoosh.Play();
    }
    
    
    
    
    
    
    
}
