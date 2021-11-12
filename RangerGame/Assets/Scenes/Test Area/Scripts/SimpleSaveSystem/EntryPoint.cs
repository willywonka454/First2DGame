using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    public string myName;
    public int ID = -100;
}

[System.Serializable]
public class EntryPointData
{
    public string myName;
    public Vector3 playerLocalScaleOnArrival;

    public EntryPointData(string newName, Vector3 newPlayerScale)
    {
        myName = newName;
        playerLocalScaleOnArrival = newPlayerScale;
    }
}