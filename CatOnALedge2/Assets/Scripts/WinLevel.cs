using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    public int currLevel;
    
    public void OnTriggerEnter(Collider cat) {
        if (cat.gameObject.tag == "Player"){
            
            if (currLevel == 0) {
                SceneManager.LoadScene("WinScene0");
            } else if (currLevel == 1) {
                SceneManager.LoadScene("WinScene1");
            } else if (currLevel == 2) {
                SceneManager.LoadScene("WinScene2");
            } else if (currLevel == 3) {
                SceneManager.LoadScene("WinScene3");
            }
        }
    }
}
