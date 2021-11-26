using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatV2 : Combat
{
    public Crossbow myCrossbow;

    public override void Start()
    {
        base.Start();

        myCrossbow = GetComponentInChildren<Crossbow>();
    }

    public override void Update()
    {
        if (Input.GetButtonDown("Fire1") && GDMContainer.myGDM.gameData.playerControls)
        {
            myCrossbow.Shoot();
        }
    }

    public override void die()
    {
        SceneObject playerCopy = new SceneObject();
        GenericSaver playerSaver = GetComponent<GenericSaver>();
        playerSaver.saveMyDataToSceneObject(playerCopy);

        int nearestVillageIndex = GDMContainer.myGDM.gameData.nearestVillageIndex;
        GDMContainer.myGDM.gameData.myScenes[nearestVillageIndex].mySceneObjects.Add(playerCopy);

        GameObject UIContainer = GameObject.FindWithTag("UIContainer");
        UIControl UIControl = UIContainer.GetComponent<UIControl>();
        UIControl.respawnMenu.SetActive(true);

        base.die();        
    }
}
