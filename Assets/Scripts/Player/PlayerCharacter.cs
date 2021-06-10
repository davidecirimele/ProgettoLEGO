using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCharacter : MonoBehaviour
{

    void Awake() {
        Messenger.AddListener(GameEvent.COLLECTED, Collect);
    }

    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.COLLECTED, Collect);
    }

    //HEALTH SYSTEM
    public Image [] hearts;
    public int life;
    private bool dead;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    //DAMAGE IMAGE
    [SerializeField] private Image damageImage;
    private Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    private float flashSpeed = 5f;
    private bool damaged;

    //SOUND
    private AudioSource _soundSource;
    [SerializeField] private AudioClip playerHurtSound;
    [SerializeField] private AudioClip collectedSound;
    [SerializeField] private AudioClip deathSound;
 
    // Start is called before the first frame update
    void Start()
    {
        life = hearts.Length;
        _soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(dead == true){
            Death();
            dead = false;
        }

        if(damaged) {
            
            damageImage.color = flashColor;
        } else {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed* Time.deltaTime);
        }
        damaged = false;

    }

    public void Hurt(int damage){

        damaged = true;
        for(int i=0;i<damage;i++){

            if(life>0){
                life -= 1;
                hearts[life].sprite = emptyHeart;
            } 
            else
                break;
        }

        if(life < 1){
            dead = true;
        } else {
            _soundSource.PlayOneShot(playerHurtSound);
        }

    }

    public void Death (){
        _soundSource.PlayOneShot(deathSound);
        Time.timeScale = 0;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        Messenger.Broadcast(GameEvent.LOSE);
    }

    private void Collect(){
        _soundSource.PlayOneShot(collectedSound);
    }

    public void Healing(){
        if(life<6){
            hearts[life].sprite = fullHeart;
            life+=1;
        }
    }
}
