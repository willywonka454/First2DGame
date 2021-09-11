using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        int currScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currScene + 1);
    }

    public void PlayCredits()
    {
        int numOfScenes = SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(numOfScenes - 1);
    }
}
