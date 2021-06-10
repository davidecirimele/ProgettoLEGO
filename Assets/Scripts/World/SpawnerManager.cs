using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnerManager : MonoBehaviour, IGameManager
{
   [SerializeField] private List<GameObject> spawnableObjects;
   [SerializeField] private GameObject spawnee;
   [SerializeField] private Transform player;

    public ManagerStatus status { get; private set; }

    void Update()
    {
        if(Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject()){
           
           Vector3 mouseScreenPosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo)){
               SpawnObjectAtPositon(hitInfo.point);
            }
        }
    }

    private void SpawnObjectAtPositon(Vector3 spawnPosition){
        if(Managers.Inventory.checkForCreation(getObjectName())){
            Managers.Audio.CreateObject();
            GameObject obj = Instantiate(spawnee, spawnPosition + spawnee.GetComponent<Offset>().getOffset(), new Quaternion(0f, player.transform.rotation.y, 0f, player.transform.rotation.w));
        }
    }

    public void Startup()
    {
        Debug.Log("Spawner Objects manager starting...");
        spawnableObjects = new List<GameObject>();
        foreach(Object obj in Resources.LoadAll("Spawnable", typeof(GameObject)))
        {
            spawnableObjects.Add(Instantiate(obj) as GameObject);
        }
        if (spawnableObjects.Count != 0)
            spawnee = spawnableObjects[2];
        status = ManagerStatus.Started;
    }

    public string getObjectName()
    {
        return spawnee.name;
    }

    public GameObject GetGameObject()
    {
        return spawnee;
    }

    public void SetSpawnee(int chObj){
        if (spawnableObjects.Count != 0)
            Managers.Audio.ChangeObjectSpawn();
            spawnee = spawnableObjects[chObj];
    }
}
