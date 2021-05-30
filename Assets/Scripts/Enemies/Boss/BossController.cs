using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    [SerializeField] private BossLife bossLife;
    [SerializeField] private DetectScript detectScript;
    [SerializeField] private Patrolling patrolling;
    [SerializeField] private ReactiveBoss reactiveBoss;
    [SerializeField] private ShootingAlienBoss shootingAlienBoss;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(detectScript.detected == true){
            bossLife.Life();
            patrolling.Move();
        }

        if(bossLife.robotDied == true){
            bossLife.Death();
            shootingAlienBoss.Shoot();
        }

        if(reactiveBoss.alienDied == true){
            detectScript.Stop();
            patrolling.Stop();
        }
    }
}
