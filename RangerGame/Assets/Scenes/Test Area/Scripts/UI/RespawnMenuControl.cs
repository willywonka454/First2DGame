using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RespawnMenuControl : MonoBehaviour
{
    public Button respawnButton;
    public Button mainMenuButton;

    void Start()
    {
        respawnButton.onClick.AddListener(respawnButtonClicked);
        mainMenuButton.onClick.AddListener(mainMenuButtonClicked);
    }

    void Update()
    {
        updateButton(respawnButton);
        updateButton(mainMenuButton);
    }

    public void updateButton(Button myButton)
    {
        if (GDMContainer.myGDM.gameData.UIInteraction == false) myButton.interactable = false;
        else myButton.interactable = true;
    }

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
