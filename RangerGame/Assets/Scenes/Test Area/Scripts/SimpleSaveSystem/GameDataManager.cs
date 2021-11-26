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

    public void prepareForNewGame()
    {
        gameData = new GameData();

        gameData.gameStart = true;
        gameData.gamePaused = true;
        gameData.playerControls = false;
        gameData.UIInteraction = true;

        MyEntireScene firstScene = returnSceneFromName(gameData.firstSceneName);

        SceneObject player = new SceneObject();
        player.myName = "MyRanger";
        player.myPos = new Vector3(-31, -4, 0);
        player.myLocalScale = new Vector3(1, 1, 1);
        firstScene.mySceneObjects.Add(player);
    }

    public MyEntireScene returnSceneFromName(string sceneName)
    {
        MyEntireScene retVal = null;

        for (int i = 0; i < gameData.myScenes.Length; i++)
        {
            if (gameData.myScenes[i].myName == sceneName)
            {
                retVal = gameData.myScenes[i];
            }
        }

        return retVal;
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

        if (myCurrentScene.hasBeenSaved) deleteSceneObjectsInWorld();

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

        string sceneNameBeforeWipe = gameData.myScenes[currSceneIndex].myName;
        gameData.myScenes[currSceneIndex] = new MyEntireScene();
        gameData.myScenes[currSceneIndex].myName = sceneNameBeforeWipe;

        Object[] saveScripts = Object.FindObjectsOfType<GenericSaver>();
        foreach (GenericSaver saveScript in saveScripts)
        {
            SceneObject sceneObject = new SceneObject();
            saveScript.saveMyDataToSceneObject(sceneObject);
            gameData.myScenes[currSceneIndex].mySceneObjects.Add(sceneObject);
        }

        gameData.myScenes[currSceneIndex].hasBeenSaved = true;
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

            SceneManager.LoadScene(gameData.currSceneIndex);

            Debug.Log(fileName + " was loaded successfully.");
        }

        else
        {
            Debug.Log(fileName + " was not loaded successfully.");
        }
    }
}
