using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResTool : MonoBehaviour
{

    public int width;
    public int height;

    public Text widthText;
    public Text heightText;

    public Toggle fullScreenToggle;

    // Start is called before the first frame update
    void Start()
    {
        width = Screen.currentResolution.width;

        height = Screen.currentResolution.height;

        fullScreenToggle.isOn = Screen.fullScreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void applyRes()
    {
        width = int.Parse(widthText.text);
        height = int.Parse(heightText.text);

        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    public void toggleScreenMode()
    {
        if (fullScreenToggle.isOn)
        {
            Screen.SetResolution(width, height, true);
        }

        else
        {
            Screen.SetResolution(width, height, false);
        }
    }
}
