using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class RespawnMenuControl : MonoBehaviour
{
    public void respawnButtonClicked()
    {
        GDMContainer.myGDM.gameData.respawnMenuIsActive = false;
        MySM.loadScene(GDMContainer.myGDM.gameData.nearestVillageIndex);
    }

    public void mainMenuButtonClicked()
    {
        saveToAutoSaveFile();
        SceneManager.LoadScene(0);      
    }

    public void saveToAutoSaveFile()
    {
        GDMContainer.myGDM.gameData.respawnMenuIsActive = true;
        GDMContainer.myGDM.saveToFile("autosave");
    }
}
