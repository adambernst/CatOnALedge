using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    
    // Audio Controls
    public AudioMixer mixer;
    public static float volumeLevel = 1.0f;
    private Slider sliderVolumeCtrl;

    void Awake (){
        SetLevel (volumeLevel);
        GameObject sliderTemp = GameObject.FindWithTag("MusicSlider");
        if (sliderTemp != null){
                sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                sliderVolumeCtrl.value = volumeLevel;
        }
    }
    
    public void SetLevel (float sliderValue) {
        mixer.SetFloat("MasterVolume", Mathf.Log10 (sliderValue) * 20);
        volumeLevel = sliderValue;
    }

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
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitGame() {
        Application.Quit();
    }
}
