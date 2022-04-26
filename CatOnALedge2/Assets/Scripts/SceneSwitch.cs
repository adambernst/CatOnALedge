using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void PlayTutorial() {
        SceneManager.LoadScene("MainScene");
    }
    
    public void PlayLevelOne() {
        SceneManager.LoadScene("LevelOne");
    }
    
}
