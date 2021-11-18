using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneTeleport : MonoBehaviour
{
    public GameObject player;
    public bool canBeTriggeredByCollision;
    public string targetSceneName = "";
    public string entryPointName = "";

    public void teleport()
    {
        MySM.loadScene(targetSceneName);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && canBeTriggeredByCollision)
        {
            GDMContainer.myGDM.gameData.entryPointData = new EntryPointData(entryPointName, col.gameObject.transform.localScale);

            player = col.gameObject;

            StartCoroutine(destroyPlayerAndThenTeleport());
        }
    }

    IEnumerator destroyPlayerAndThenTeleport()
    {
        addPlayerToNextScene();

        Destroy(player);

        yield return null;

        teleport();
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
}
