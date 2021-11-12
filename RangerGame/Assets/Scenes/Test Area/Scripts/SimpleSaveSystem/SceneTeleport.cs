using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneTeleport : MonoBehaviour
{
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
        if (col.gameObject.tag == "Player")
        {
            GDMContainer.myGDM.gameData.entryPointData = new EntryPointData(entryPointName, col.gameObject.transform.localScale);
            teleport();
        }
    }
}
