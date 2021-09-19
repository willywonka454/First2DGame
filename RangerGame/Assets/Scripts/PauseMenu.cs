using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    GameObject[] pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.FindGameObjectsWithTag("PauseMenu");
        hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale > 0f)
            {                
                Time.timeScale = 0f;                
                show();
                GlobalVars.acceptingUserInput = false;
            }
            else
            {
                resume();
            }
        }
    }

    void hide()
    {
        foreach (GameObject pauseUI in pauseMenu)
        {
            pauseUI.SetActive(false);
        }
    }

    void show()
    {
        foreach (GameObject pauseUI in pauseMenu)
        {
            pauseUI.SetActive(true);
        }
    }

    public void resume()
    {
        Time.timeScale = 1f;        
        hide();
        GlobalVars.acceptingUserInput = true;
    }

    public void restart()
    {
        resume();
        SceneData.reset();
        GlobalVars.reset();
        LevelControl.loadLevelByIndex(1);
    }

    public void mainMenu()
    {
        resume();
        GlobalVars.reset();
        LevelControl.loadLevelByIndex(0);
    }

    public void quit()
    {
        Application.Quit();
    }
}
