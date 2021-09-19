using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{

    public static int getNumScenes()
    {
        return SceneManager.sceneCountInBuildSettings;
    }

    public static int getCurrScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public static string getSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(getCurrScene());
    }

    public static void loadNextLevel()
    {
        if (getCurrScene() < getNumScenes() - 1)
        {
            SceneManager.LoadScene(getCurrScene() + 1);
        }            
    }

    public static void loadPreviousLevel()
    {
        if (getCurrScene() > 0)
        {
            SceneManager.LoadScene(getCurrScene() - 1);
        }
    }

    public static void loadLevelByIndex(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public static void loadLevelByName(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
