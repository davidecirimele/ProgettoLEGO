using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offset : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    public void setOffset(float x, float y, float z)
    {
        offset = new Vector3(x, y, z);
    }

    public Vector3 getOffset()
    {
        return offset;
    }

}
