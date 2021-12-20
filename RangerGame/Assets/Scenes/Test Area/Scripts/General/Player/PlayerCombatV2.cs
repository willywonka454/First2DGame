using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatV2 : Combat
{
    public Crossbow myCrossbow;
    public PlayerInventoryV2 myInventory;

    public override void Start()
    {
        base.Start();

        myCrossbow = GetComponentInChildren<Crossbow>();
        myInventory = GetComponent<PlayerInventoryV2>();
    }

    public override void Update()
    {
        if (Input.GetButtonDown("Fire1") && GDMContainer.myGDM.gameData.playerControls && myInventory.arrows > 0)
        {
            myCrossbow.Shoot();
            myInventory.removeArrows(1);
        }
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Fireball")
        {
            takeDamage(20);
        }

        if (col.gameObject.tag == "Coin")
        {
            Coin myCoin = col.gameObject.GetComponent<Coin>();
            myInventory.addCoins(myCoin.value);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Skeleton")
        {
            takeDamage(20);
        }

        if (col.gameObject.tag == "Bat")
        {
            takeDamage(20);
        }

        if (col.gameObject.tag == "Dragon")
        {
            takeDamage(20);
        }
    }

    public void sendPetToVillageAndThenDestroyReference()
    {
        GameObject pet = GameObject.FindWithTag("Pet");

        if (pet != null)
        {
            SceneObject petCopy = new SceneObject();
            GenericSaver petSaver = pet.GetComponent<GenericSaver>();
            petSaver.saveMyDataToSceneObject(petCopy);

            int nearestVillageIndex = GDMContainer.myGDM.gameData.nearestVillageIndex;
            GDMContainer.myGDM.gameData.myScenes[nearestVillageIndex].mySceneObjects.Add(petCopy);
        }

        Destroy(pet);
    }

    public override void die()
    {
        Debug.Log("Died.");

        sendPetToVillageAndThenDestroyReference();

        SceneObject playerCopy = new SceneObject();
        GenericSaver playerSaver = GetComponent<GenericSaver>();
        playerSaver.saveMyDataToSceneObject(playerCopy);
        playerCopy.hp = 100;

        int nearestVillageIndex = GDMContainer.myGDM.gameData.nearestVillageIndex;
        GDMContainer.myGDM.gameData.myScenes[nearestVillageIndex].mySceneObjects.Add(playerCopy);

        GameObject UIContainer = GameObject.FindWithTag("UIContainer");
        UIControl UIControl = UIContainer.GetComponent<UIControl>();
        UIControl.respawnMenu.SetActive(true);

        base.die();        
    }    
}
