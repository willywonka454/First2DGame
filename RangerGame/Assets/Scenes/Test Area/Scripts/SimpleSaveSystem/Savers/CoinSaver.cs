using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSaver : GenericSaver
{
    public override void saveMyDataToSceneObject(SceneObject sceneObject)
    {
        base.saveMyDataToSceneObject(sceneObject);

        sceneObject.myName = "Coin object.";
    }
}
