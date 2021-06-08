using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    private Dictionary<string, int> _items;
    private string objectChoose;
    public void Startup()
    {
        Debug.Log("Inventory manager starting...");
        _items = new Dictionary<string, int>();
        objectChoose = GetComponent<SpawnerManager>().getObjectName();
        status = ManagerStatus.Started;
    }

    private void DisplayItems()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Inventory"))
        {
            if (obj.name == "wood" && _items.ContainsKey("Wood"))
                obj.GetComponentInChildren<Text>().text = "Legno\n" + _items["Wood"];
            if (obj.name == "metal" && _items.ContainsKey("Metal"))
                obj.GetComponentInChildren<Text>().text = "Metallo\n" + _items["Metal"];
            if (obj.name == "special" && _items.ContainsKey("Cannon"))
                obj.GetComponentInChildren<Text>().text = "Pezzi\nCannone\n" + _items["Cannon"];
        }
    }

    private void changeObject()
    {

    }

    public void AddItem(string name)
    {
        if (_items.ContainsKey(name))
        {
            _items[name] += 1;
        }
        else
        {
            _items[name] = 1;
        }
        DisplayItems();
    }

    public List<string> GetItemList()
    {
        List<string> list = new List<string>(_items.Keys);
        return list;
    }

    public int getItemCount(string name)
    {
        if (_items.ContainsKey(name))
        {
            return _items[name];
        }
        return 0;
    }

    public void consumeItem(string name)
    {
        if (_items.ContainsKey(name))
        {
            _items[name]--;
            if (_items[name] == 0)
            {
                _items.Remove(name);
            }
        } else
        {
            Debug.Log("Cannot consume " + name);
        }
        DisplayItems();
    }

    public bool checkForCreation(string obj){
        
        if(obj == "AlienTranporter(Clone)" && getItemCount("Metal") >= 6){
            consumeItem("Metal");
            return true;
        }

        if(obj == "Bridge(Clone)" && getItemCount("Wood") >= 3 && getItemCount("Metal") >= 1){
            consumeItem("Wood");
            consumeItem("Metal");
            return true;
        }

        if(obj == "Ladder(Clone)" && getItemCount("Wood") >= 1){
            consumeItem("Wood");
            return true;
        }

        return false;
    }
}
