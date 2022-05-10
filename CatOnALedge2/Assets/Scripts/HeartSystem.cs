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
    public int currLevel;
    
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
            if (currLevel == 0) {
                SceneManager.LoadScene("DeathScene0");
            } else if (currLevel == 1) {
                SceneManager.LoadScene("DeathScene1");
            } else if (currLevel == 2) {
                SceneManager.LoadScene("DeathScene2");
            } else if (currLevel == 3) {
                SceneManager.LoadScene("DeathScene3");
            }
            
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
