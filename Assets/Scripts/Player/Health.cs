using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public double health;
    public int numOfHearts;

    public int[] hearts;
    public Image[] spritehearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        numOfHearts=3;

            for (int i = 0; i < numOfHearts; i++){
                hearts[i]=2;
                health+=1;
            }

            
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numOfHearts; i++){
            if(hearts[i]==2)
                spritehearts[i].sprite = fullHeart;
            else if(hearts[i]==1)
                spritehearts[i].sprite = halfHeart;
            else
                spritehearts[i].sprite = emptyHeart;
        }

        
        
    }

    public double getHealth(){
        return health;
    }

    public void updateHealth(){

        for(int i=hearts.Length-1;i>=0;i--)
            if(hearts[i]!=0){
                hearts[i]-=1;
                health-=0.5;
                break;
            }


    }
}
