using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<SceneObject> sceneObjects = new List<SceneObject>();

    public MyEntireScene[] myScenes;

    public GameData()
    {
        myScenes = new MyEntireScene[LevelControl.getNumScenes()];

        myScenes[0] = new MyEntireScene();
            
        myScenes[0].mySceneObjects.Add(new SceneObject());
    }
}
