using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    public string name;
    public int ID;

    public EntryPoint(int newID, string newName)
    {
        ID = newID;
        name = newName;
    }
}
