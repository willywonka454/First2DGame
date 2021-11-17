using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneTeleport : MonoBehaviour
{
    public bool canBeTriggeredByCollision;

    // A SceneTeleport will have a target destination (a scene).
    public string targetSceneName = "";

    // A SceneTeleport will have a desired entry point in the target destination. 
    public string entryPointName = "";

    // A SceneTeleport should be able to teleport the player to the target destination.
    public void teleport()
    {
        MySM.loadScene(targetSceneName);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && canBeTriggeredByCollision)
        {
            GDMContainer.myGDM.gameData.entryPointData = new EntryPointData(entryPointName, col.gameObject.transform.localScale);

            GameObject player = col.gameObject;
            GenericSaver playerSaver = col.gameObject.GetComponent<GenericSaver>();

            SceneObject playerSceneObject = new SceneObject();
            playerSaver.saveMyDataToSceneObject(playerSceneObject);

            MyEntireScene targetScene = GDMContainer.myGDM.returnSceneFromName(targetSceneName);
            targetScene.mySceneObjects.Add(playerSceneObject);

            StartCoroutine(destroyPlayerAndThenTeleport(player));
        }
    }

    IEnumerator destroyPlayerAndThenTeleport(GameObject player)
    {
        Destroy(player);

        yield return null;

        teleport();
    }
}
