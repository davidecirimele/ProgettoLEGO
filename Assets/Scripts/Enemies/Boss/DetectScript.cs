using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScript : MonoBehaviour
{
    bool detected;
    GameObject target;
    public Transform enemy;

    [SerializeField] private GameObject bullet;
    private GameObject _laser;
    public Transform shootPoint;

    public float shootSpeed = 10f;
    public float timeToShoot = 1.3f;
    float originalTime;

     void Awake() {
        
        Messenger.AddListener(GameEvent.BOSS_ALIEN_KILLED, Stop);    
    }

    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.BOSS_ALIEN_KILLED, Stop); 
    }

    // Start is called before the first frame update
    void Start()
    {
        originalTime = timeToShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if(detected){
            enemy.LookAt(target.transform);
            Messenger.Broadcast(GameEvent.DETECTED);
        }
    }

    void FixedUpdate() {
        if(detected){
            timeToShoot -= Time.deltaTime;

            if(timeToShoot < 0){
                if(shootPoint != null)
                    ShootPlayer();
                timeToShoot = originalTime;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            detected = true;
            target = other.gameObject;
        }
    }

    private void ShootPlayer(){
        
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
    }

    private void Stop(){
        detected = false;
    }
}
