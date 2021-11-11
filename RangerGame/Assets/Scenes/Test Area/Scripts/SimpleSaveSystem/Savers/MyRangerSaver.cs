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

        if (currScene.mySceneObjects.Count <= 0)
        {
            GameData myGameData = GDMContainer.myGDM.gameData;

            if (myGameData.entryExists)
            {
                Object[] entryPoints = Object.FindObjectsOfType<EntryPoint>();

                if (string.IsNullOrEmpty(myGameData.entryName))
                {
                    foreach (EntryPoint ep in entryPoints)
                    {
                        if (ep.ID == myGameData.entryID)
                        {
                            transform.position = ep.gameObject.transform.position;
                            transform.localScale = myGameData.entryPlayerLocalScale;
                        }
                    }
                }

                else
                {
                    foreach (EntryPoint ep in entryPoints)
                    {
                        if (ep.myName == myGameData.entryName)
                        {
                            transform.position = ep.gameObject.transform.position;
                            transform.localScale = myGameData.entryPlayerLocalScale;
                        }
                    }
                }

                myGameData.entryExists = false;
            }
        }
    }

    public override void saveMyDataToSceneObject(SceneObject sceneObject)
    {
        base.saveMyDataToSceneObject(sceneObject);
        sceneObject.myName = "MyRanger";
    }

    public override void loadDataFromSceneObjectToMyGameObject(SceneObject sceneObject)
    {
        base.loadDataFromSceneObjectToMyGameObject(sceneObject);
    }
}
