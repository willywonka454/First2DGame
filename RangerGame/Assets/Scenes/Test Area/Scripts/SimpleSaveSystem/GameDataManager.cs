using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class GameDataManager : MonoBehaviour
{
    public string saveFile;
    public string gameSavesPath;
    public GameData gameData = new GameData();
    public List<string> targetTags = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        gameSavesPath = Path.Combine(Application.persistentDataPath, "GameSaves");

        if (!Directory.Exists(gameSavesPath))
        {
            Directory.CreateDirectory(gameSavesPath);
        }

        GameObject test = (UnityEngine.GameObject) Resources.Load("Dball");

        Instantiate(test);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> returnAllGameObjectsToLoad()
    {
        return null;
    }

    public void loadGameObjectsIntoUnity()
    {
        // for each gameObject in gameObjectsToLoad, get that gameObject's UniversalSaveAndLoadProtocol component.
        // Then, get their specific save and loader and call GenericSaveAndLoader.loadSceneObject();
    }

    public List<GameObject> returnAllGameObjectsToSave()
    {
        List<GameObject> gameObjectsToSave = new List<GameObject>();

        foreach (string targetTag in targetTags)
        {
            GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);
            foreach (GameObject targetObject in targetObjects)
            {
                gameObjectsToSave.Add(targetObject);
            }
        }

        return gameObjectsToSave;
    }

    public void saveGameObjectsToGameData(List<GameObject> gameObjectsToSave)
    {
        foreach (GameObject gameObjectToSave in gameObjectsToSave)
        {
            GeneralSaver mySaveProtocol = gameObjectToSave.GetComponent<GeneralSaver>();
            SceneObject sceneObject = mySaveProtocol.returnSceneObject();
            gameData.sceneObjects.Add(sceneObject);
        }
    }

    public void saveToFile(string fileName)
    {
        saveGameObjectsToGameData(returnAllGameObjectsToSave());

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
