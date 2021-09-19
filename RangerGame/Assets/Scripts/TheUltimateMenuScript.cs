using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheUltimateMenuScript : MonoBehaviour
{    

    public enum MenuState
    {
        Shop,
        GameOver,
        Victory,
        Pause,
        Empty
    }

    public MenuState currState;

    public GameObject[] menus;

    // Start is called before the first frame update
    void Start()
    {
        changeState(MenuState.Empty);       
    }

    // Update is called once per frame
    void Update()
    {
        handleUserInput();
    }

    void handleUserInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currState == MenuState.Pause) 
            {
                changeState(MenuState.Empty);
            }

            else if (currState == MenuState.Empty || currState == MenuState.Shop)
            {
                changeState(MenuState.Pause);
            }
        }

        else if (Input.GetKeyDown(KeyCode.S) && GlobalVars.playerInVillage)
        {
            if (currState == MenuState.Shop)
            {
                changeState(MenuState.Empty);
            }

            else if (currState == MenuState.Empty)
            {
                changeState(MenuState.Shop);
            }
        }

        else if (GlobalVars.dragonDead)
        {
            changeState(MenuState.Victory);
        }

        else if (GlobalVars.playerDead)
        {
            changeState(MenuState.GameOver);
        }
    }

    void enableCurrState()
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (i != (int) currState)
            {
                menus[i].SetActive(false);
            }

            else
            {
                menus[i].SetActive(true);
            }
        }
    }

    public void changeState(MenuState newState)
    {
        currState = newState;
        enableCurrState();
    }
}
