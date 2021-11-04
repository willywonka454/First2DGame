using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class GameDataManager : MonoBehaviour
{
    public string saveFile;
    public string gameSavesPath;
    public GameData localData = new GameData();

    // Start is called before the first frame update
    void Start()
    {
        gameSavesPath = Path.Combine(Application.persistentDataPath, "GameSaves");

        if (!Directory.Exists(gameSavesPath))
        {
            Directory.CreateDirectory(gameSavesPath);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deleteAllSceneObjectsInWorld()
    {
        Object[] saveScripts = Object.FindObjectsOfType<GenericSaver>();

        foreach (GenericSaver saveScript in saveScripts)
        {
            Destroy(saveScript.gameObject);
        }
    }

    public void deleteSceneObjectsInLocalData()
    {
        localData.sceneObjects.Clear();
    }

    public void loadSceneObjectsIntoWorld()
    {
        deleteAllSceneObjectsInWorld();

        foreach (SceneObject sceneObject in localData.sceneObjects)
        {
            GameObject newGameObject = (UnityEngine.GameObject)Resources.Load(sceneObject.myName);
            GenericSaver myLoaderScript = newGameObject.GetComponent<GenericSaver>();
            myLoaderScript.loadDataFromSceneObjectToMyGameObject(sceneObject);
            Instantiate(newGameObject, newGameObject.GetComponent<Transform>().position, newGameObject.GetComponent<Transform>().rotation);
        }
    }

    public void saveLocalSceneObjects()
    {
        deleteSceneObjectsInLocalData();

        Object[] saveScripts = Object.FindObjectsOfType<GenericSaver>();

        foreach (GenericSaver saveScript in saveScripts)
        {
            SceneObject sceneObject = new SceneObject();
            saveScript.saveMyDataToSceneObject(sceneObject);
            localData.sceneObjects.Add(sceneObject);
        }
    }

    public void saveToFile(string fileName)
    {
        saveLocalSceneObjects();

        saveFile = Path.Combine(gameSavesPath, fileName + ".json");

        string jsonString = JsonUtility.ToJson(localData, true);

        File.WriteAllText(saveFile, jsonString);
    }

    public void loadFile(string fileName)
    {
        saveFile = Path.Combine(gameSavesPath, fileName + ".json");

        if (File.Exists(saveFile))
        {
            string fileContents = File.ReadAllText(saveFile);

            localData = JsonUtility.FromJson<GameData>(fileContents);

            loadSceneObjectsIntoWorld();

            Debug.Log(fileName + " was loaded successfully.");
        }

        else
        {
            Debug.Log(fileName + " was not loaded successfully.");
        }
    }
}
