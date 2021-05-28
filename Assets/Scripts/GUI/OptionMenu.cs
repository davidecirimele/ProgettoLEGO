using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private Text pauseText;
    [SerializeField] private Text winText;
    [SerializeField] private Text loseText;
    
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button escButton;

    public void OpenPause(){
        PauseGame();
        pauseText.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
        optionButton.gameObject.SetActive(true);
        escButton.gameObject.SetActive(true);
    }

    public void ClosePause(){
        UnPauseGame();
        pauseText.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        optionButton.gameObject.SetActive(false);
        escButton.gameObject.SetActive(false);
    }

    public void WinGame(){
        PauseGame();
        winText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        optionButton.gameObject.SetActive(true);
        escButton.gameObject.SetActive(true);
    }

    public void LoseGame(){
        PauseGame();
        loseText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        optionButton.gameObject.SetActive(true);
        escButton.gameObject.SetActive(true);
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
