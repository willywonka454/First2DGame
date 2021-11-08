using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class SimpleSaveController : MonoBehaviour
{
    public Button saveAsButton;
    public Button loadFileButton;
    public TMP_InputField fileInputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveAsClicked()
    {
        GDMContainer.myGDM.saveToFile(fileInputField.text);
    }

    public void loadFileClicked()
    {
        GDMContainer.myGDM.loadFile(fileInputField.text);
    }
}
