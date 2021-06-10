using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    public GameObject Projectile;

    [SerializeField] private Transform target;
    [SerializeField] private int layerMask;
    public float time;
    private GameObject BossLife;

    void Start()
    {
        time = 0.1f;
        layerMask = ~ (1 << LayerMask.NameToLayer("Player"));
        Cursor.lockState = CursorLockMode.Locked; // lock mouse on the center 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Managers.Audio.ShootAlien();
            Ray ray = new Ray(target.position, (transform.position - target.position) * 200);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 200f, layerMask))
            {
                Debug.Log(hit.transform.gameObject.name);
                StartCoroutine(SpawnBulletTrail(hit.point));
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (hit.transform.tag == "Alien"){
                    hit.transform.GetComponent<FollowerAI>().KillIt();
                }
                if (hit.transform.tag == "Destroyable")
                    hit.transform.GetComponent<DestroyAndDrop>().Damage();
                if (hit.transform.tag == "Boss")
                    if (hit.transform.GetComponent<BossLife>() != null)
                        hit.transform.GetComponent<BossLife>().Hitted(1);
                    else
                    {
                        BossLife = GameObject.Find("TankFree_Yel");
                        BossLife.GetComponent<BossLife>().Hitted(1);
                    }
                if (hit.transform.tag == "BossAlien")
                    hit.transform.GetComponent<ReactiveBoss>().ReactToHit();
                if (target != null)
                    target.ReactToHit(); 
            }
        }
    }

    private IEnumerator SpawnBulletTrail(Vector3 hitPoint)
    {
        GameObject laser = GameObject.CreatePrimitive(PrimitiveType.Cube);
        laser.GetComponent<Renderer>().material.color = Color.red;
        laser.GetComponent<BoxCollider>().enabled = false;
        laser.transform.localScale = new Vector3(0.05f, 0.05f, 0.4f);
        laser.transform.position = transform.position;
        laser.transform.rotation = Quaternion.LookRotation(hitPoint - transform.position, Vector3.up);
        float i = 0f;
        float rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            laser.transform.position = Vector3.Lerp(transform.position, hitPoint, i);
            yield return null;
        }
        Destroy(laser.gameObject);
    }
}

