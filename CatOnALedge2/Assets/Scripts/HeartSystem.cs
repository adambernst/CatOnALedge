using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    private int life; 
    private bool dead;
    
    void Start() {
        life = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true) {
            // DEATH SCREEN AND SUCH
            Debug.Log("WE ARE DEAD !!!");
        }
    
    }
    
    public void TakeDamage(int d) {
        Debug.Log("Taking damage!");
        if (life >= 1) {
            Debug.Log("in if statement");
            life -= d;
            Destroy(hearts[life].gameObject);
            if (life < 1) 
                dead = true;
        }
    }
}
