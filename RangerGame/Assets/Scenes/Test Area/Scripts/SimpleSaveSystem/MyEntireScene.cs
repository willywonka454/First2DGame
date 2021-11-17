using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MyEntireScene
{
    public string myName;
    public bool hasBeenSaved = false;
    public List<SceneObject> mySceneObjects = new List<SceneObject>();
}
