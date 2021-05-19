using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnable : MonoBehaviour
{
    public string name;
    public Dictionary<string, int> objectNeeded;

    private void Awake()
    {
        objectNeeded = new Dictionary<string, int>();
    }
}
