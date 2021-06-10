using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlienTransporterScript : MonoBehaviour
{
    public float seconds = 40;

    private AudioSource _soundSource;
    [SerializeField] private AudioClip startSound;

    private bool fly = false;
    private float timePassed = 0;

    void Start(){
        seconds = 40;
        _soundSource = GetComponent<AudioSource>();
    }

    void Update(){
        if (fly == true && seconds > 0) {
            transform.Translate(0, 3f * Time.deltaTime, 8f * Time.deltaTime);
            Debug.Log(seconds);
            seconds -= Time.deltaTime;
        }
        else
        {
            fly = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        CharacterController player = other.GetComponent<CharacterController>();
        

        if(player != null){
           fly = true;
           _soundSource.PlayOneShot(startSound);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        CharacterController player = other.GetComponent<CharacterController>();
        if (player != null && fly)
        {
            player.Move(new Vector3(0, 3f * Time.deltaTime, 8f * Time.deltaTime));
        }
    }

    private void OnTriggerExit(Collider other) {
        CharacterController player = other.GetComponent<CharacterController>();
        if(player != null){
            _soundSource.mute = !_soundSource.mute;
        }
    }
}
