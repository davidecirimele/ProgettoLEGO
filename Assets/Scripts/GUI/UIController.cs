using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] private StartMenu startMenu;
    [SerializeField] private GameInterface gameInterface;
    [SerializeField] private OptionMenu optionMenu;

    void Awake() {
        Messenger.AddListener(GameEvent.WIN, Win);
        Messenger.AddListener(GameEvent.LOSE, Lose);    
    }

    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.WIN, Win);
        Messenger.RemoveListener(GameEvent.LOSE, Lose); 
    }

    // Start is called before the first frame update
    void Start()
    {
        startMenu.Open();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
           
            if(GameEvent.isPaused == false){
                optionMenu.OpenPause();
            } else {
                optionMenu.ClosePause();
            }
        }   
    }

    public void OnPlay(){
        startMenu.Play();
        gameInterface.Play();
    }

    public void QuitGame(){
        startMenu.Exit();
    }

    public void Win(){
        optionMenu.WinGame();
    }

    public void Lose(){
        optionMenu.LoseGame();
    }
}
