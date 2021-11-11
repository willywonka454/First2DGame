using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    public MyEntireScene[] myScenes;
    public int currSceneIndex;

    public bool entryExists = false;
    public int entryID = -100;
    public string entryName = null;
    public Vector3 entryPlayerLocalScale = Vector3.zero;

    public GameData()
    {
        myScenes = new MyEntireScene[SceneManager.sceneCountInBuildSettings];

        for (int i = 0; i < myScenes.Length; i++)
        {
            myScenes[i] = new MyEntireScene();
        }
    }
}
