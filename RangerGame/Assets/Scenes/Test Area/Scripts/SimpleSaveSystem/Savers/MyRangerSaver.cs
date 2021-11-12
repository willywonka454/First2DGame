using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MyRangerSaver : GenericSaver
{
    // Start is called before the first frame update
    public override void Start()
    {
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        MyEntireScene currScene = GDMContainer.myGDM.gameData.myScenes[currSceneIndex];
        if (!currScene.hasBeenSaved && entryPointExists()) assignPlayerToEntryPoint();
    }

    public override void saveMyDataToSceneObject(SceneObject sceneObject)
    {
        base.saveMyDataToSceneObject(sceneObject);
        sceneObject.myName = "MyRanger";
    }

    public override void loadDataFromSceneObjectToMyGameObject(SceneObject sceneObject)
    {
        base.loadDataFromSceneObjectToMyGameObject(sceneObject);
        
        if (entryPointExists())
        {
            assignPlayerToEntryPoint();
        }
    }

    public void assignPlayerToEntryPoint()
    {
        Vector3 newPos = findMyEntryPointPos();
        transform.position = newPos;
        transform.localScale = GDMContainer.myGDM.gameData.entryPointData.playerLocalScaleOnArrival;
        GDMContainer.myGDM.gameData.entryPointData.isEmpty = true;
    }

    public Vector3 findMyEntryPointPos()
    {
        string myEntryPointName = GDMContainer.myGDM.gameData.entryPointData.myName;
        Object[] entryPoints = Object.FindObjectsOfType<EntryPoint>();        
        foreach (EntryPoint entryPoint in entryPoints)
        {
            if (entryPoint.myName == myEntryPointName)
            {
                return entryPoint.transform.position;
            }
        }

        return new Vector3(0, 0, 0);
    }

    public bool entryPointExists()
    {
        GameData gameData = GDMContainer.myGDM.gameData;

        if (gameData.entryPointData.isEmpty) return false;
        else return true;
    }
}
