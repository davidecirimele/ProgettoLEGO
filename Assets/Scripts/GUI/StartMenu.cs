using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Image wallpaper;
    [SerializeField] private Button gioca;
    [SerializeField] private Button comandi;
    [SerializeField] private Button storia;
    [SerializeField] private Button esci;
    [SerializeField] private AudioClip sound;

    public GameObject menuStart;
    public GameObject menuCommand;
    public GameObject menuStory;

    public GameObject logo;

    void Start() {
        Managers.Audio.PlayIntroMusic();
    }

    public void Open(){
        
        this.gameObject.SetActive(true);
    }

    public void Play(){
        Managers.Audio.PlaySound(sound);
        GameEvent.isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scena");
    }

    public void goToCommand(){
        menuStart.SetActive(false);
        menuStory.SetActive(false);
        menuCommand.SetActive(true);
    }

    public void goToStart(){
        menuStart.SetActive(true);
        menuStory.SetActive(false);
        menuCommand.SetActive(false);
        logo.SetActive(true);
    }

    public void goToStory(){
        menuStart.SetActive(false);
        menuStory.SetActive(true);
        menuCommand.SetActive(false);
        logo.SetActive(false);
    }

    public void Exit(){
        Managers.Audio.PlaySound(sound);
        Application.Quit();
    }

    private void PauseGame(){
        GameEvent.isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    private void UnPauseGame(){
        GameEvent.isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}
