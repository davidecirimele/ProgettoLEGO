using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScript : MonoBehaviour
{
    public bool detected;
    GameObject target;
    public Transform enemy;
    public Transform ShootTower;

    [SerializeField] private GameObject bullet;
    private GameObject _laser;
    public Transform shootPoint;

    [SerializeField] private SpinWheels wheel1;
    [SerializeField] private SpinWheels wheel2;
    [SerializeField] private SpinWheels wheel3;
    [SerializeField] private SpinWheels wheel4;
    
    public float timeToShoot = 1.3f;
    float originalTime;

    // Start is called before the first frame update
    void Start()
    {
        originalTime = timeToShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if(detected){
            if(ShootTower != null){
                ShootTower.LookAt(target.transform);
                wheel1.setStart();
                wheel2.setStart();
                wheel3.setStart();
                wheel4.setStart();
            }
               
            else
                enemy.LookAt(target.transform);
            
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
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();

        if(player != null){
            Messenger.Broadcast(GameEvent.BOSS_FIGHT);
            detected = true;
            target = other.gameObject;
        }
    }

    private void ShootPlayer(){
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, ShootTower.rotation);
        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward);
    }

    public void Stop(){
        detected = false;
    }
}
