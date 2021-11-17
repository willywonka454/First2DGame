using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class SaveFileButtonControl : MonoBehaviour
{
    public Button myButton;
    public string myFileName;

    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();

        TMP_Text myButtonText = GetComponentInChildren<TMP_Text>();

        myFileName = myButtonText.text;

        myButton.onClick.AddListener(() => loadSaveFile(myFileName));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadSaveFile(string myFileName)
    {
        GDMContainer.myGDM.loadFile(myFileName);
    }
}
