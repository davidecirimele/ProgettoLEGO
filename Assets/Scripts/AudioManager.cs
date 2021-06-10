using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status {get; private set;}

    public float musicVolume{
        get {return musicSource.volume; }
        set { 
            if(musicSource != null){
                musicSource.volume = value;
            }
        }
    }

    public bool musicMute{
        get {
                if(musicSource != null){
                    return musicSource.mute;
                }
                return false; 
            }
        set { 
            if(musicSource != null){
                musicSource.mute = value;
            }
        }
    }

    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private string introBGMusic;
    [SerializeField] private string levelBGMusic;

    [SerializeField] private AudioClip destroySound;
    [SerializeField] private AudioClip createSound;
    [SerializeField] private AudioClip selectSound;
    [SerializeField] private AudioClip diedSound;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip biteSound;

    public void PlaySound(AudioClip clip){
        soundSource.PlayOneShot(clip);
    }

    public float soundVolume{
        get {return AudioListener.volume;}
        set {AudioListener.volume = value;}
    }

    public bool soundMute{
        get {return AudioListener.pause;}
        set {AudioListener.pause = value;}
    }

    public void PlayIntroMusic() {
        PlayMusic((AudioClip)Resources.Load("Music/"+introBGMusic));
    }

    public void PlayLevelMusic() {
        PlayMusic((AudioClip)Resources.Load("Music/"+levelBGMusic));
    }

    private void PlayMusic(AudioClip clip){
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic(){
        musicSource.Stop();
    }

    public void Startup(){
        Debug.Log("Audio manager starting...");

        musicSource.ignoreListenerVolume = true;
        musicSource.ignoreListenerPause = true;

        soundVolume = 1f;
        musicVolume = 0.5f;
        
        status = ManagerStatus.Started;
    }

    public void DestructionObject(){
        soundSource.PlayOneShot(destroySound);
    }

    public void CreateObject(){
        soundSource.PlayOneShot(createSound);
    }

    public void ChangeObjectSpawn(){
        soundSource.PlayOneShot(selectSound);
    }

    public void AlienDied(){
        soundSource.PlayOneShot(diedSound);
    }

    public void ShootAlien(){
        soundSource.PlayOneShot(shootSound);
    }

    public void BiteAlien(){
        soundSource.PlayOneShot(biteSound);
    }
}
