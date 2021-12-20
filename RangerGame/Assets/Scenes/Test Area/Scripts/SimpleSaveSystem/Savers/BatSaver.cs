using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSaver : GenericSaver
{
    public override void saveMyDataToSceneObject(SceneObject sceneObject)
    {
        BatMovement batMovement = GetComponent<BatMovement>();
        sceneObject.dirY = batMovement.dirY;
        sceneObject.myPos = transform.position;
        sceneObject.myRotation = transform.rotation;
        sceneObject.myLocalScale = transform.localScale;
        sceneObject.myName = gameObject.tag;
    }

    public override void loadDataFromSceneObjectToMyGameObject(SceneObject sceneObject)
    {
        BatMovement batMovement = GetComponent<BatMovement>();
        batMovement.dirY = sceneObject.dirY;
        transform.position = sceneObject.myPos;
        transform.rotation = sceneObject.myRotation;
        transform.localScale = sceneObject.myLocalScale;
    }
}
