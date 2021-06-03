using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLife : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image fillImg;
    private float barValueDamage;
    private Image healthBarBackground;
    private bool damaged;
    private int health;

    void Awake() {
        healthBar.gameObject.SetActive(false);
        Messenger.AddListener(GameEvent.DETECTED, Life);    
    }

     void OnDestroy() {
        Messenger.RemoveListener(GameEvent.DETECTED, Life);
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 40;
        barValueDamage = healthBar.maxValue / health;
        healthBarBackground = healthBar.GetComponentInChildren <Image> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
        Death ();
        }
        damaged = false;
    }

    public void Hitted(int damage){
        damaged = true;
        health -= damage;
        healthBar.value -= barValueDamage;
        Debug.Log("Boss Health: " + health);
    }

    public void Death (){
        
        Destroy(this.gameObject);
        Messenger.Broadcast(GameEvent.BOSS_ROBOT_KILLED);
    }

    private void Life(){
        healthBar.gameObject.SetActive(true);
    }

}