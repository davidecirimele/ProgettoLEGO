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

    private AudioSource _soundSource;
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private AudioClip deadSound;


    // Start is called before the first frame update
    void Start()
    {
        _soundSource = GetComponent<AudioSource>();
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
            _soundSource.PlayOneShot(explosionSound);
            shootingAlienBoss.Shoot();
        }

        if(reactiveBoss.alienDied == true){
            _soundSource.PlayOneShot(deadSound);
            detectScript.Stop();
            patrolling.Stop();
            reactiveBoss.alienDied = false;
        }
    }
}
