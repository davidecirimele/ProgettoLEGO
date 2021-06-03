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
    //private bool damaged;
    private int health;
    public bool robotDied;

    void Awake() {
        healthBar.gameObject.SetActive(false);
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
        robotDied = true;
        }
        //damaged = false;
    }

    public void Hitted(int damage){
        //damaged = true;
        health -= damage;
        healthBar.value -= barValueDamage;
        Debug.Log("Boss Health: " + health);
    }

    public void Death (){
        
        Destroy(this.gameObject);
        robotDied = false;
    }

    public void Life(){
        healthBar.gameObject.SetActive(true);
    }

}
