using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using System.IO;

public class GameDataManager
{    
    public string saveFile;
    public string gameSavesPath;
    public GameData gameData = new GameData();

    public GameDataManager()
    {
        gameSavesPath = Path.Combine(Application.persistentDataPath, "GameSaves");

        if (!Directory.Exists(gameSavesPath))
        {
            Directory.CreateDirectory(gameSavesPath);
        }
    }

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

    public void deleteSceneObjectsInWorld()
    {
        Object[] saveScripts = Object.FindObjectsOfType<GenericSaver>();

        foreach (GenericSaver saveScript in saveScripts)
        {
            Object.Destroy(saveScript.gameObject);
        }
    }

    public void loadCurrentScene()
    {
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        MyEntireScene myCurrentScene = gameData.myScenes[currSceneIndex];

        if (myCurrentScene.mySceneObjects.Count > 0) deleteSceneObjectsInWorld();

        foreach (SceneObject sceneObject in myCurrentScene.mySceneObjects)
        {
            GameObject myPrefab = Resources.Load<GameObject>(sceneObject.myName);
            GameObject myGameObject = Object.Instantiate(myPrefab);
            GenericSaver myLoaderScript = myGameObject.GetComponent<GenericSaver>();
            myLoaderScript.loadDataFromSceneObjectToMyGameObject(sceneObject);
        }
    }

    public void saveCurrentScene()
    {
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameData.myScenes[currSceneIndex] = new MyEntireScene();

        Object[] saveScripts = Object.FindObjectsOfType<GenericSaver>();
        foreach (GenericSaver saveScript in saveScripts)
        {
            SceneObject sceneObject = new SceneObject();
            saveScript.saveMyDataToSceneObject(sceneObject);
            gameData.myScenes[currSceneIndex].mySceneObjects.Add(sceneObject);
        }
    }

    public void saveToFile(string fileName)
    {
        saveCurrentScene();

        saveFile = Path.Combine(gameSavesPath, fileName + ".json");

        string jsonString = JsonUtility.ToJson(gameData, true);

        File.WriteAllText(saveFile, jsonString);
    }

    public void loadFile(string fileName)
    {
        saveFile = Path.Combine(gameSavesPath, fileName + ".json");

        if (File.Exists(saveFile))
        {
            string fileContents = File.ReadAllText(saveFile);

            gameData = JsonUtility.FromJson<GameData>(fileContents);

            Debug.Log(fileName + " was loaded successfully.");
        }

        else
        {
            Debug.Log(fileName + " was not loaded successfully.");
        }
    }
}
