using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSaver : MonoBehaviour
{
    public virtual void saveMyDataToSceneObject(SceneObject sceneObject)
    {
        sceneObject.myPos = transform.position;        
        sceneObject.myRotation = transform.rotation;
        sceneObject.myLocalScale = transform.localScale;
        sceneObject.myName = gameObject.tag;
    }

    public virtual void loadDataFromSceneObjectToMyGameObject(SceneObject sceneObject)
    {
        transform.position = sceneObject.myPos;
        transform.rotation = sceneObject.myRotation;
        transform.localScale = sceneObject.myLocalScale;
    }
}
