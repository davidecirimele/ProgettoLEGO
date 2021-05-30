using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Image wallpaper;
    [SerializeField] private Button gioca;
    [SerializeField] private Button esci;

    public void Open(){
        
        this.gameObject.SetActive(true);
    }

    public void Play(){
        GameEvent.isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scena");
        
    }

    public void Exit(){
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
