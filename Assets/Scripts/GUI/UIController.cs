using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameInterface gameInterface;
    [SerializeField] private PopupMenu popupMenu;
    [SerializeField] private OptionMenuScript optionMenuScript;
    
    private bool inOption = false;

    void Awake() {
        Messenger.AddListener(GameEvent.WIN, Win);
        Messenger.AddListener(GameEvent.LOSE, Lose);
        gameInterface.Play();
        Managers.Audio.PlayLevelMusic();
    }

    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.WIN, Win);
        Messenger.RemoveListener(GameEvent.LOSE, Lose); 
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
           
            if(GameEvent.isPaused == false){
                popupMenu.OpenPause();
                gameInterface.Pause();
            } else {
                
                if(inOption == true){
                        popupMenu.Back();
                        inOption = false;
                } else {
                    popupMenu.ClosePause();
                    gameInterface.Play();
                } 
            }
        }   
    }

    public void Win(){
        popupMenu.WinGame();
    }

    public void Lose(){
        popupMenu.LoseGame();
    }

    public void OnExit(){
        popupMenu.Esc();
    }

    public void OnResume(){
        popupMenu.ClosePause();
        gameInterface.Play();
    }

    public void OnRestart(){
        popupMenu.Restart();
    }

    public void OnOption(){
        popupMenu.Option();
        inOption = true;
    }

    public void BackOption(){
        popupMenu.Back();
    }
}
