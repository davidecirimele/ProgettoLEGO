using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    private Dictionary<string, int> _items;

    public void Startup()
    {
        Debug.Log("Inventory manager starting...");
        _items = new Dictionary<string, int>();
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
        }
        else
        {
            Debug.Log("Cannot consume " + name);
        }
        DisplayItems();
    }
}
