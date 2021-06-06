using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlienTransporterScript : MonoBehaviour
{

    private AudioSource _soundSource;
    [SerializeField] private AudioClip startSound;

    private bool fly = false;
    //private CharacterController player;

    void Start(){
        _soundSource = GetComponent<AudioSource>();
    }

    void Update(){
        if(fly == true){
            transform.Translate(0, 3f * Time.deltaTime, 8f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) {
        CharacterController player = other.GetComponent<CharacterController>();
        

        if(player != null){
           fly = true;
           _soundSource.PlayOneShot(startSound);
           player.transform.parent = transform;
           //player.Move(0, 3f * Time.deltaTime, 8f * Time.deltaTime);
        }

    }

    private void OnTriggerExit(Collider other) {
        CharacterController player = other.GetComponent<CharacterController>();
        

        if(player != null){
            _soundSource.mute = !_soundSource.mute;
           player.transform.parent = null;
        }
    }
}
