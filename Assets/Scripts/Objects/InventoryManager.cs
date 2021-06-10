using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    private Dictionary<string, int> _items;
    private string objectChoose;
    public Image objectImage;

    public void Startup()
    {
        Debug.Log("Inventory manager starting...");
        _items = new Dictionary<string, int>();
        objectChoose = GetComponent<SpawnerManager>().getObjectName();
        changeObject("ladder");
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
        }
    }

    public void changeObject(string image)
    {
        objectImage.sprite = Resources.Load<Sprite>("Spawnable Images/" + image);
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

    public void consumeItem(int value, string name)
    {
        if (_items.ContainsKey(name))
        {
            if (_items[name] < value)
                return;
            _items[name] -= value;
            DisplayItems();
            if (_items[name] == 0)
            {
                _items.Remove(name);
            }
        } else
        {
            Debug.Log("Cannot consume " + name);
        }
    }

    public bool checkForCreation(string obj){
        
        if(obj == "AlienTransporter(Clone)" && getItemCount("Metal") >= 20){
            consumeItem(20, "Metal");
            return true;
        }

        if(obj == "Bridge(Clone)" && getItemCount("Wood") >= 7 && getItemCount("Metal") >= 5){
            consumeItem(7, "Wood");
            consumeItem(5, "Metal");
            return true;
        }

        if(obj == "Ladder(Clone)" && getItemCount("Wood") >= 5){
            consumeItem(5, "Wood");
            return true;
        }
        
        return false;
    }
}
