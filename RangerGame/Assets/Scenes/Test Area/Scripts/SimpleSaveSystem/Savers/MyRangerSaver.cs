using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MyRangerSaver : GenericSaver
{
    public MyHealth playerHealth;
    public PlayerInventoryV2 playerInventory;

    public override void Awake()
    {
        playerHealth = GetComponent<MyHealth>();
        playerInventory = GetComponent<PlayerInventoryV2>();
    }

    public override void saveMyDataToSceneObject(SceneObject sceneObject)
    {
        base.saveMyDataToSceneObject(sceneObject);

        sceneObject.hp = playerHealth.myHP;
        sceneObject.arrows = playerInventory.arrows;
        sceneObject.coins = playerInventory.coins;

        sceneObject.myName = "MyRanger";
    }

    public override void loadDataFromSceneObjectToMyGameObject(SceneObject sceneObject)
    {
        base.loadDataFromSceneObjectToMyGameObject(sceneObject);

        playerHealth.myHP = sceneObject.hp;
        playerInventory.arrows = sceneObject.arrows;
        playerInventory.coins = sceneObject.coins;

        if (base.entryPointExists())
        {
            base.assignPlayerToEntryPoint();
        }
    }
}
