using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCharacter : MonoBehaviour
{

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
 
    // Start is called before the first frame update
    void Start()
    {
        life = hearts.Length;
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
        life -= damage;
        hearts[life].sprite = emptyHeart;
        //Destroy(hearts[life].gameObject);

        if(life < 1){
            dead = true;
        }
    }

    public void Death (){
        Time.timeScale = 0;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        Messenger.Broadcast(GameEvent.LOSE);
    }
}
