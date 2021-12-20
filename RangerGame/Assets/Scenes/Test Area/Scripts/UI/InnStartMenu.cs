using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class InnStartMenu : MonoBehaviour
{
    [Header("Opening")]
    public GameObject openingPanel;
    public Button openingPanelOkButton;
    public Button openingPanelHelpfulTipsButton;

    [Header("Helpful tips")]
    public GameObject helpfulTipsPanel;
    public Button helpfulTipsOkButton;
    public Button helpfulTipsBackButton;

    // Start is called before the first frame update
    void Start()
    {
        openingPanel.SetActive(true);
        helpfulTipsPanel.SetActive(false);

        openingPanelOkButton.onClick.AddListener(openingPanelOkAction);
        openingPanelHelpfulTipsButton.onClick.AddListener(openingHelpfulTipsAction);

        helpfulTipsOkButton.onClick.AddListener(helpfulTipsOkAction);
        helpfulTipsBackButton.onClick.AddListener(helpfulTipsBackAction);
    }

    // Update is called once per frame
    void Update()
    {
        updateButton(openingPanelOkButton);
        updateButton(openingPanelHelpfulTipsButton);
        updateButton(helpfulTipsOkButton);
        updateButton(helpfulTipsBackButton);
    }

    void OnEnable()
    {
        if (GDMContainer.myGDM.gameData.gameStart)
        {
            Time.timeScale = 0;
            GDMContainer.myGDM.gameData.playerControls = false;
            GDMContainer.myGDM.gameData.gamePaused = true;
        }
    }

    void OnDisable()
    {

    }

    void updateButton(Button myButton)
    {
        if (GDMContainer.myGDM.gameData.UIInteraction == false) myButton.interactable = false;
        else myButton.interactable = true;
    }

    public void openingPanelOkAction()
    {
        openingPanel.SetActive(false);
        helpfulTipsPanel.SetActive(false);
        Time.timeScale = 1;
        GDMContainer.myGDM.gameData.gameStart = false;
        GDMContainer.myGDM.gameData.playerControls = true;
        GDMContainer.myGDM.gameData.gamePaused = false;
    }

    public void helpfulTipsOkAction()
    {
        openingPanel.SetActive(false);
        helpfulTipsPanel.SetActive(false);        
        Time.timeScale = 1;
        GDMContainer.myGDM.gameData.gameStart = false;
        GDMContainer.myGDM.gameData.playerControls = true;
        GDMContainer.myGDM.gameData.gamePaused = false;
    }

    public void openingHelpfulTipsAction()
    {
        openingPanel.SetActive(false);
        helpfulTipsPanel.SetActive(true);
    }

    public void helpfulTipsBackAction()
    {
        openingPanel.SetActive(true);
        helpfulTipsPanel.SetActive(false);
    }
}
