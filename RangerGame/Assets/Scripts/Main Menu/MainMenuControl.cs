using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class MainMenuControl : MonoBehaviour
{
    public TMP_Dropdown resolutionChoices;
    public Resolution[] resolutions;

    public Toggle fullscreenToggle;

    void Start()
    {
        resolutions = Screen.resolutions;
        populateResolutions();
    }

    public void populateResolutions()
    {        
        List<string> resolutionStrings = new List<string>();

        for(int i = 0; i < resolutions.Length; i++)
        {
            string newResolution = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "Hz";

            resolutionStrings.Add(newResolution);
        }

        resolutionChoices.ClearOptions();

        resolutionChoices.AddOptions(resolutionStrings);

        resolutionChoices.value = resolutions.Length - 1;
    }

    public void resolutionChanged()
    {
        Resolution selectedResolution = resolutions[resolutionChoices.value];

        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen, selectedResolution.refreshRate);
    }

    public void fullscreenToggled()
    {
        if (fullscreenToggle.isOn)
        {
            Resolution selectedResolution = resolutions[resolutionChoices.value];

            Screen.SetResolution(selectedResolution.width, selectedResolution.height, true, selectedResolution.refreshRate);
        }
        else
        {
            Screen.fullScreen = false;
        }
    }
}
