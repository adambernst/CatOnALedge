using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    private int life; 
    private bool dead;
    
    public GameObject musicPlayer;
    private AudioFX audioFX;
    
    void Start() {
        life = hearts.Length;
        audioFX = musicPlayer.GetComponent<AudioFX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true) {
            audioFX.PlayLostLife();
            SceneManager.LoadScene("DeathScene");
        }
    
    }
    
    public void TakeDamage(int d) {

        if (life >= 1) {
            audioFX.PlayLostLife();
            life -= d;
            Destroy(hearts[life].gameObject);
            if (life < 1) 
                dead = true;
        }
    }
}
