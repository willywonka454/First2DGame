using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    public MyEntireScene[] myScenes;
    public int currSceneIndex;
    public string firstSceneName;

    public string nearestVillageName;
    public int nearestVillageIndex;

    public bool respawnMenuIsActive;
    public bool playerControls;
    public bool playerMovementControls;
    public bool UIInteraction;
    public bool gameStart;
    public bool gamePaused;
    public bool dragIsDead;
    public bool justLoadedASave;
    public bool hasBoughtPet;

    public bool camLocked;
    public float camOrthoSize;

    public EntryPointData entryPointData;
    
    public GameData()
    {        
        myScenes = new MyEntireScene[SceneManager.sceneCountInBuildSettings];
        for (int i = 0; i < myScenes.Length; i++)
        {
            myScenes[i] = new MyEntireScene();
            myScenes[i].myName = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }

        firstSceneName = "Inn 1";

        playerControls = true;
        UIInteraction = true;

        entryPointData = new EntryPointData();
    }
}
