using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSaver : GeneralSaver
{
    public override void saveDataToSceneObject()
    {
        base.saveDataToSceneObject();

        sceneObject.myTag = "Coin object.";
    }
}
