using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneTeleport : MonoBehaviour
{
    public GameObject player;
    public GameObject pet;
    public bool canBeTriggeredByCollision;
    public string targetSceneName = "";
    public string entryPointName = "";

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && canBeTriggeredByCollision)
        {
            GDMContainer.myGDM.gameData.entryPointData = new EntryPointData(entryPointName, col.gameObject.transform.localScale);

            player = col.gameObject;

            destroyPlayerAndThenTeleportWrapper();
        }
    }

    public void destroyPlayerAndThenTeleportWrapper()
    {
        StartCoroutine(destroyPlayerAndThenTeleport());
    }

    IEnumerator destroyPlayerAndThenTeleport()
    {
        addPlayerToNextScene();
        addPetToNextScene();
        
        Destroy(player);
        Destroy(pet);

        yield return null;

        teleport();
    }

    public void teleport()
    {
        MySM.loadScene(targetSceneName);
    }

    public void addPlayerToNextScene()
    {
        GDMContainer.myGDM.gameData.entryPointData = new EntryPointData(entryPointName, player.transform.localScale);

        GenericSaver playerSaver = player.GetComponent<GenericSaver>();
        SceneObject playerSceneObject = new SceneObject();
        playerSaver.saveMyDataToSceneObject(playerSceneObject);

        MyEntireScene targetScene = GDMContainer.myGDM.returnSceneFromName(targetSceneName);
        targetScene.mySceneObjects.Add(playerSceneObject);
    }

    public void addPetToNextScene()
    {
        pet = GameObject.FindWithTag("Pet");

        if (pet != null)
        {
            GenericSaver petSaver = pet.GetComponent<GenericSaver>();
            SceneObject petSceneObject = new SceneObject();
            petSaver.saveMyDataToSceneObject(petSceneObject);

            MyEntireScene targetScene = GDMContainer.myGDM.returnSceneFromName(targetSceneName);
            targetScene.mySceneObjects.Add(petSceneObject);
        }
        
    }
}
