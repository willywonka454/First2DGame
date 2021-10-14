using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HudButton : MonoBehaviour
{
    public Button myButton;

    public bool showingMyObjects;

    public List<GameObject> myObjects;

    public HudGroup myGroup; // All the UI in this group should be disable when clicking on, like in osrs

    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(clicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clicked()
    {
        if (showingMyObjects)
        {
            hideMyObjects();
        }

        else
        {
            hideObjectsInMyGroup();

            showMyObjects();
        }
    }

    public void hideMyObjects()
    {
        for(int i = 0; i < myObjects.Count; i++)
        {
            myObjects[i].SetActive(false);

            showingMyObjects = false;
        }
    }

    public void showMyObjects()
    {
        for (int i = 0; i < myObjects.Count; i++)
        {
            myObjects[i].SetActive(true);

            showingMyObjects = true;
        }
    }

    public void hideObjectsInMyGroup()
    {
        for (int i = 0; i < myGroup.groupObjects.Count; i++)
        {
            HudButton objectInGroup = myGroup.groupObjects[i].GetComponent<HudButton>();
            
            if (objectInGroup != this.gameObject) {
                objectInGroup.hideMyObjects();
            }
        }
    }
}
