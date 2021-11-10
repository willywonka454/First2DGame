using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public static class MySM
{
    public static int getNumScenes()
    {
        return SceneManager.sceneCountInBuildSettings;
    }

    public static Scene getScene(int index = 0, string name = null)
    {
        Scene retVal;

        if (name == null)
        {
            retVal = SceneManager.GetSceneByBuildIndex(index);
        }

        else
        {
            retVal = SceneManager.GetSceneByName(name);
        }

        return retVal;
    }

    public static void loadScene(int index = 0, string name = null)
    {
        if (name == null)
        {
            SceneManager.LoadScene(index);
        }

        else
        {
            SceneManager.LoadScene(name);
        }
    }
}
