using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EnterableCorrespondency : MonoBehaviour
{
    void Start()
    {
        string mySceneName = SceneManager.GetActiveScene().name;

        string mySceneNumber = "" + mySceneName[mySceneName.Length - 1];

        SceneTeleport sceneTeleport = GetComponent<SceneTeleport>();

        sceneTeleport.targetSceneName = sceneTeleport.targetSceneName + " " + mySceneNumber; 
    }
}
