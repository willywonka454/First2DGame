using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class ButtonListTest : MonoBehaviour
{
    public GameObject buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        string[] saveFileNames = getSaveFileNames();

        for (int i = 0; i < saveFileNames.Length; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, gameObject.transform);
            TMP_Text textComponent = newButton.GetComponentInChildren<TMP_Text>();
            textComponent.text = saveFileNames[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string[] getSaveFileNames()
    {
        string[] retVal = new string[0];

        if (Directory.Exists(GDMContainer.myGDM.gameSavesPath))
        {
            DirectoryInfo gameSavesFolder = new DirectoryInfo(GDMContainer.myGDM.gameSavesPath);

            FileInfo[] saveFiles = gameSavesFolder.GetFiles();
            retVal = new string[saveFiles.Length];
            for(int i = 0; i < retVal.Length; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(saveFiles[i].Name);
                retVal[i] = fileName;
            }
        }

        return retVal;
    }
}
