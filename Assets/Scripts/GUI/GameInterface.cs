using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInterface : MonoBehaviour
{
    public void Play(){
        this.gameObject.SetActive(true);  
    }

    public void Pause(){
        this.gameObject.SetActive(false);
    }
}
