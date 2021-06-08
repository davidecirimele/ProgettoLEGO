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
            ShootTower.LookAt(target.transform);
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
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, ShootTower.rotation);
        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward);
    }

    public void Stop(){
        detected = false;
    }
}
