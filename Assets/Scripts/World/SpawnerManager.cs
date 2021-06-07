using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnerManager : MonoBehaviour, IGameManager
{
   [SerializeField] private List<GameObject> spawnableObjects;
   [SerializeField] private GameObject spawnee;

    public ManagerStatus status { get; private set; }

    // Update is called once per frame
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
        Managers.Audio.CreateObject();
        GameObject obj = Instantiate(spawnee, spawnPosition + spawnee.GetComponent<Offset>().getOffset(), Quaternion.identity);
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
            spawnee = spawnableObjects[0];
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
}
