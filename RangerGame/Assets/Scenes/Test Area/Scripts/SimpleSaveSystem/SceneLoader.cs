using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Awake()
    {
        Scene activeScene = SceneManager.GetActiveScene();

        if (activeScene.name.Contains("Village"))
        {
            GDMContainer.myGDM.gameData.nearestVillageName = activeScene.name;
            GDMContainer.myGDM.gameData.nearestVillageIndex = activeScene.buildIndex;
        }
        GDMContainer.myGDM.loadCurrentScene();
        GDMContainer.myGDM.gameData.currSceneIndex = activeScene.buildIndex;
    }
}
