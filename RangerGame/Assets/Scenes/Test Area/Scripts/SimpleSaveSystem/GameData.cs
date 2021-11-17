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
    public EntryPointData entryPointData;
    
    public GameData()
    {        
        myScenes = new MyEntireScene[SceneManager.sceneCountInBuildSettings];
        for (int i = 0; i < myScenes.Length; i++)
        {
            myScenes[i] = new MyEntireScene();
            myScenes[i].myName = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }

        entryPointData = new EntryPointData();
    }
}
