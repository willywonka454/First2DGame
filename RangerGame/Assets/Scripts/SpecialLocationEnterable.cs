using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SpecialLocationEnterable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool mouseHoveringOver;
    public GameObject myText;

    public DetectRadius myRadius;
    public SceneTeleport myTeleporter;

    // Start is called before the first frame update
    void Start()
    {
        myRadius = GetComponent<DetectRadius>();
        myTeleporter = GetComponent<SceneTeleport>();

        myTeleporter.player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (myRadius.targetDetected())
        {
            myText.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E))
            {
                myAction();
            }
        }

        else if (mouseHoveringOver)
        {
            myText.SetActive(true);
        }

        else
        {
            myText.SetActive(false);
        }
    }

    public virtual void myAction()
    {
        myTeleporter.destroyPlayerAndThenTeleportWrapper();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseHoveringOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseHoveringOver = false;
    }
}
