using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }
    
    public void Resume() {
        pauseMenuUI.SetActive(false); // hide pause menu
        Time.timeScale = 1f; // play game
        GameIsPaused = false;
    }
    
    void Pause() {
        pauseMenuUI.SetActive(true); // show pause menu
        Time.timeScale = 0f; // freeze game
        GameIsPaused = true;
    }
    
    public void LoadMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitGame() {
        Application.Quit();
    }
}
