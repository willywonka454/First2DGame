using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuControl : MonoBehaviour
{
    [Header ("Sound")]
    public TMP_Text musicVolumeLevelText;
    public TMP_Text effectsVolumeLevelText;
    public Slider musicSlider;
    public Slider effectsSlider;

    [Header ("Graphics")]
    public TMP_Dropdown resolutionDropdown;
    public Resolution[] resolutions;
    public Toggle fullscreenToggle;
    public bool initializing = true;

    [Header("Save Game")]
    public TMP_InputField saveAsInputField;
    public Button saveAsButton;
    public GameObject saveFileList;

    [Header("In-game buttons")]
    public Button resumeButton;
    public Button returnToMainMenuButton;
    public Button inGameQuitButton;    

    [Header("Variables")]
    public bool amEscapeMenu;
    public bool prevGamePaused;
    public bool prevPlayerControls;
    public bool prevUIInteraction;

    void Start()
    {        
        initializeGraphics();

        initializeSound();

        // Add actions to some in game menu buttons.
        if (amEscapeMenu)
        {
            resumeButton.onClick.AddListener(resume);
            returnToMainMenuButton.onClick.AddListener(returnToMainMenu);
            inGameQuitButton.onClick.AddListener(quitFromInGame);
        }
    }

    void Update()
    {
        
    }

    void OnEnable()
    {
        if (amEscapeMenu)
        {
            prevGamePaused = GDMContainer.myGDM.gameData.gamePaused;
            prevPlayerControls = GDMContainer.myGDM.gameData.playerControls;
            prevUIInteraction = GDMContainer.myGDM.gameData.UIInteraction;

            GDMContainer.myGDM.gameData.gamePaused = true;
            GDMContainer.myGDM.gameData.playerControls = false;
            GDMContainer.myGDM.gameData.UIInteraction = false;

            Time.timeScale = 0;
        }
    }

    void OnDisable()
    {
        if (amEscapeMenu)
        {
            GDMContainer.myGDM.gameData.gamePaused = prevGamePaused;
            GDMContainer.myGDM.gameData.playerControls = prevPlayerControls;
            GDMContainer.myGDM.gameData.UIInteraction = prevUIInteraction;

            if (GDMContainer.myGDM.gameData.gamePaused) Time.timeScale = 0;
            else Time.timeScale = 1;
        }        
    }

    // In game methods
    public void resume()
    {
        gameObject.SetActive(false);
    }

    public void returnToMainMenu()
    {
        saveToFileFromAutoSave();
        gameObject.SetActive(false);   
        SceneManager.LoadScene("MainMenu");
    }

    public void quitFromInGame()
    {
        saveToFileFromAutoSave();
        Application.Quit();        
    }

    public void showMainPanelOnly()
    {
        
    }

    public void saveToFile(string fileName)
    {
        GDMContainer.myGDM.gameData.gamePaused = prevGamePaused;
        GDMContainer.myGDM.gameData.playerControls = prevPlayerControls;
        GDMContainer.myGDM.gameData.UIInteraction = prevUIInteraction;

        GDMContainer.myGDM.saveToFile(fileName);
        ButtonListTest savesList = saveFileList.GetComponent<ButtonListTest>();
        savesList.insertNewSaveAtRuntime(fileName);

        GDMContainer.myGDM.gameData.gamePaused = true;
        GDMContainer.myGDM.gameData.playerControls = false;
        GDMContainer.myGDM.gameData.UIInteraction = false;
    }

    public void saveToFileFromUserInput()
    {
        string fileName = saveAsInputField.text;
        saveToFile(fileName);
    }

    public void saveToFileFromAutoSave()
    {
        string fileName = "autosave";
        saveToFile(fileName);
    }

    // New game methods
    public void newGame()
    {
        GDMContainer.myGDM.prepareForNewGame();
        SceneManager.LoadScene(GDMContainer.myGDM.gameData.firstSceneName);
    }

    // Exit and credit methods
    public void exitButtonClicked()
    {
        Application.Quit();
    }

    public void creditsButtonClicked()
    {
        GlobalVars.indexOfPrevLevel = LevelControl.getCurrScene();

        LevelControl.loadLevelByName("Credits");
    }

    // Sound methods
    public void initializeSound()
    {
        float savedMusic = PlayerPrefs.GetFloat("musicVolume", musicSlider.maxValue / 2);
        float savedEffects = PlayerPrefs.GetFloat("effectsVolume", effectsSlider.maxValue / 2);

        musicSlider.value = savedMusic;
        effectsSlider.value = savedEffects;
    }

    public void musicSliderChanged()
    {
        float newVal = (musicSlider.value / musicSlider.maxValue) * 100;

        musicVolumeLevelText.text = newVal.ToString("0") + "%";

        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }

    public void effectsSliderChanged()
    {
        float newVal = (effectsSlider.value / effectsSlider.maxValue) * 100;

        effectsVolumeLevelText.text = newVal.ToString("0") + "%";

        PlayerPrefs.SetFloat("effectsVolume", effectsSlider.value);
    }

    // Graphics methods
    public void initializeGraphics()
    {
        resolutions = Screen.resolutions;

        populateResolutions();

        fullscreenToggle.isOn = Screen.fullScreen;

        initializing = false;
    }

    public void populateResolutions()
    {        
        List<string> resolutionStrings = new List<string>();

        for(int i = 0; i < resolutions.Length; i++)
        {
            string newResolution = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "Hz";

            resolutionStrings.Add(newResolution);
        }

        resolutionDropdown.ClearOptions();

        resolutionDropdown.AddOptions(resolutionStrings);

        int savedIndex = PlayerPrefs.GetInt("resolutionIndex", resolutions.Length - 1);

        if (savedIndex < resolutions.Length)
        {
            resolutionDropdown.value = savedIndex;
        } 

        else
        {
            resolutionDropdown.value = resolutions.Length - 1;
        }
        
    }

    public void resolutionChanged()
    {
        if (!initializing)
        {
            Resolution selectedResolution = resolutions[resolutionDropdown.value];

            Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen, selectedResolution.refreshRate);
        }

        PlayerPrefs.SetInt("resolutionIndex", resolutionDropdown.value);
    }

    public void fullscreenToggled()
    {
        if (fullscreenToggle.isOn)
        {
            Resolution selectedResolution = resolutions[resolutionDropdown.value];

            Screen.SetResolution(selectedResolution.width, selectedResolution.height, true, selectedResolution.refreshRate);
        }

        else
        {
            Screen.fullScreen = false;
        }
    }
}
