using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {        
        initializeGraphics();

        initializeSound();
    }

    void Update()
    {
        // If Screen.Resolution not same as current resolution, save to playerprefs
    }

    // New game methods
    public void newGame()
    {
        LevelControl.loadLevelByName("Forest 2");
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
