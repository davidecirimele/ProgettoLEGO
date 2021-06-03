using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupMenu : MonoBehaviour
{
    [SerializeField] private Text pauseText;
    [SerializeField] private Text winText;
    [SerializeField] private Text loseText;
    
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button escButton;
    [SerializeField] private GameObject optionMenu;

    [SerializeField] private AudioClip sound;

    public void OpenPause(){
        PauseGame();
        this.gameObject.SetActive(true);
        pauseText.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
        optionButton.gameObject.SetActive(true);
        escButton.gameObject.SetActive(true);
    }

    public void ClosePause(){
        Managers.Audio.PlaySound(sound); 
        UnPauseGame();
        this.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        optionButton.gameObject.SetActive(false);
        escButton.gameObject.SetActive(false);
    }

    public void WinGame(){
        PauseGame();
        this.gameObject.SetActive(true);
        winText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        //optionButton.gameObject.SetActive(true);
        escButton.gameObject.SetActive(true);
        escButton.transform.localPosition += new Vector3(0, 35, 0);
    }

    public void LoseGame(){
        PauseGame();
        this.gameObject.SetActive(true);
        loseText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        //optionButton.gameObject.SetActive(true);
        escButton.gameObject.SetActive(true);
        escButton.transform.localPosition += new Vector3(0, 35, 0);
    }

    public void Restart(){
        Managers.Audio.PlaySound(sound); 
        GameEvent.isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scena");
    }

    public void Option(){
        Managers.Audio.PlaySound(sound);
        pauseText.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        optionButton.gameObject.SetActive(false);
        escButton.gameObject.SetActive(false);
        optionMenu.gameObject.SetActive(true);
    }

    public void Back(){
        Managers.Audio.PlaySound(sound);
        pauseText.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
        optionButton.gameObject.SetActive(true);
        escButton.gameObject.SetActive(true);
        optionMenu.gameObject.SetActive(false);
    }

    public void Esc(){
        Managers.Audio.PlaySound(sound);
        SceneManager.LoadScene("Start Menu");
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
