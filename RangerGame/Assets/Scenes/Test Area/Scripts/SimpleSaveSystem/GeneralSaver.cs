using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSaver : MonoBehaviour
{

    public SceneObject sceneObject;

    public virtual void saveDataToSceneObject()
    {
        sceneObject = new SceneObject();
        sceneObject.myPos = GetComponent<Transform>().position;
        sceneObject.myLocalScale = GetComponent<Transform>().localScale;
        sceneObject.myTag = "Generic scene object.";
    }

    public SceneObject returnSceneObject()
    {
        saveDataToSceneObject();
        return sceneObject;
    }
}
