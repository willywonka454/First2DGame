using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    [Header ("Menus")]
    public GameObject respawnMenu;
    public GameObject escapeMenu;
    public GameObject innStartMenu;
    public GameObject shopMenu;

    [Header("Enterable locations")]
    public GameObject enterInn;
    public GameObject exitInn;
    [Space (10)]
    public GameObject enterShop;
    public GameObject exitShop;

    // Start is called before the first frame update
    void Start()
    {
        if (GDMContainer.myGDM.gameData.respawnMenuIsActive) respawnMenu.SetActive(true);
        else
        {
            string mySceneName = SceneManager.GetActiveScene().name;
            if (mySceneName == "Inn")
            {
                if (GDMContainer.myGDM.gameData.gameStart)
                {
                    innStartMenu.SetActive(true);
                    Time.timeScale = 0;
                }
                exitInn.SetActive(true);
            }
            else if (mySceneName == "Shop")
            {
                shopMenu.SetActive(true);
                exitShop.SetActive(true);
            }
            else if (mySceneName.Contains("Village"))
            {
                enterInn.SetActive(true);
                enterShop.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        escapeMenuActivation();
    }

    void escapeMenuActivation()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && escapeMenu.activeSelf)
        {
            escapeMenu.SetActive(false);

            GDMContainer.myGDM.gameData.playerControls = true;
            GDMContainer.myGDM.gameData.UIInteraction = true;

            if (GDMContainer.myGDM.gameData.gamePaused == false) Time.timeScale = 1;
            if (innStartMenu.activeSelf || shopMenu.activeSelf) GDMContainer.myGDM.gameData.playerControls = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !escapeMenu.activeSelf)
        {
            escapeMenu.SetActive(true);

            GDMContainer.myGDM.gameData.playerControls = false;
            GDMContainer.myGDM.gameData.UIInteraction = false;

            if (Time.timeScale == 0) GDMContainer.myGDM.gameData.gamePaused = true;
            Time.timeScale = 0;            
        }
    }
}
