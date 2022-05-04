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
    // public AudioMixer mixer;
    // public static float MusicVolumeLevel = 1.0f;
    // public static float FXVolumeLevel = 1.0f;
    // private Slider MusicSliderVolumeCtrl;
    // private Slider FXSliderVolumeCtrl;
    // 
    // void Awake (){
    //         mixer.SetFloat("MusicVolume", Mathf.Log10 (MusicVolumeLevel) * 20);
    //         // MusicVolumeLevel = 
    // 
    //         GameObject MusicSliderTemp = GameObject.FindWithTag("MusicSlider");
    //         if (MusicSliderTemp != null){
    //                 MusicSliderVolumeCtrl = MusicSliderTemp.GetComponent<Slider>();
    //                 MusicSliderVolumeCtrl.value = MusicVolumeLevel;
    //         }
    // 
    //         mixer.SetFloat("SFXVolume", Mathf.Log10 (FXVolumeLevel) * 20);
    //         // FXVolumeLevel = sliderValue;
    // 
    //         GameObject FXSliderTemp = GameObject.FindWithTag("FXSlider");
    //         if (FXSliderTemp != null){
    //                 FXSliderVolumeCtrl = FXSliderTemp.GetComponent<Slider>();
    //                 FXSliderVolumeCtrl.value = FXVolumeLevel;
    //         }
    // }

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
