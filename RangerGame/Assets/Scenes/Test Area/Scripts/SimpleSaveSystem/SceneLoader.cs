using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {        
        GDMContainer.myGDM.loadCurrentScene();
        GDMContainer.myGDM.gameData.currSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}