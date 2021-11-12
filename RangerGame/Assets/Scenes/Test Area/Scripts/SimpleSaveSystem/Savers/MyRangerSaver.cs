using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MyRangerSaver : GenericSaver
{
    // Start is called before the first frame update
    public override void Start()
    {
        GameData gameData = GDMContainer.myGDM.gameData;
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        MyEntireScene currScene = gameData.myScenes[currSceneIndex];
        if (!currScene.hasBeenSaved && gameData.entryPointData != null) assignPlayerToEntryPoint();
    }

    public override void saveMyDataToSceneObject(SceneObject sceneObject)
    {
        base.saveMyDataToSceneObject(sceneObject);
        sceneObject.myName = "MyRanger";
    }

    public override void loadDataFromSceneObjectToMyGameObject(SceneObject sceneObject)
    {
        base.loadDataFromSceneObjectToMyGameObject(sceneObject);

        if (GDMContainer.myGDM.gameData.entryPointData != null) assignPlayerToEntryPoint();
    }

    public void assignPlayerToEntryPoint()
    {
        Vector3 newPos = findMyEntryPointPos();
        transform.position = newPos;
        transform.localScale = GDMContainer.myGDM.gameData.entryPointData.playerLocalScaleOnArrival;
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
}
