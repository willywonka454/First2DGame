using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneTeleport : MonoBehaviour
{
    // A SceneTeleport will have a target destination (a scene).
    public int targetSceneIndex = 0;
    public string targetSceneName = "";

    // A SceneTeleport will have a desired entry point in the target destination. 
    public int entryPointID = -100;
    public string entryPointName = "";

    // A SceneTeleport should be able to teleport the player to the target destination.
    public void teleport()
    {
        if (string.IsNullOrEmpty(targetSceneName)) targetSceneName = null;

        MySM.loadScene(targetSceneIndex, targetSceneName);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GDMContainer.myGDM.gameData.entryExists = true;
            GDMContainer.myGDM.gameData.entryID = entryPointID;
            GDMContainer.myGDM.gameData.entryName = entryPointName;
            GDMContainer.myGDM.gameData.entryPlayerLocalScale = col.gameObject.transform.localScale;

            teleport();
        }
    }
}
