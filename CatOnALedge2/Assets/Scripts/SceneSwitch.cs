using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayTutorial() {
        SceneManager.LoadScene("NewTutorial");
    }
    
    public void PlayLevelOne() {
        SceneManager.LoadScene("NewOne");
    }
    
   
    public void ToLevelTwo()
    {
        SceneManager.LoadScene("NewTwo");
    }

    public void ToLevelThree()
    {
        SceneManager.LoadScene("LevelTwo");
    }

}
