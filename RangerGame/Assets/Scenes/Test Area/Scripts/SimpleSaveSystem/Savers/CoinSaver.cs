using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSaver : GenericSaver
{
    public override void saveMyDataToSceneObject(SceneObject sceneObject)
    {
        Coin coin = GetComponent<Coin>();
        sceneObject.value = coin.value;
        sceneObject.myPos = transform.position;
        sceneObject.myRotation = transform.rotation;
        sceneObject.myLocalScale = transform.localScale;
        sceneObject.myName = gameObject.tag;
    }

    public override void loadDataFromSceneObjectToMyGameObject(SceneObject sceneObject)
    {
        Coin coin = GetComponent<Coin>();
        coin.value = sceneObject.value;
        transform.position = sceneObject.myPos;
        transform.rotation = sceneObject.myRotation;
        transform.localScale = sceneObject.myLocalScale;
    }
}
