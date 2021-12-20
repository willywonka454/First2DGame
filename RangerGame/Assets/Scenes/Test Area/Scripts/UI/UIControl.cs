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
    [Space(10)]
    public GameObject enterCellar;
    public GameObject exitCellar;
    public GameObject enterPrison;
    public GameObject enterCastleInterior;
    public GameObject enterMountain;
    public GameObject enterFinalBoss;

    [Header("Canvases")]
    public GameObject worldSpaceCanvas;
    public GameObject cameraSpaceCanvas;

    [Header("Scene teleport to credits")]
    public GameObject sceneTeleportToCredits;

    // Start is called before the first frame update
    void Start()
    {
        if (GDMContainer.myGDM.gameData.respawnMenuIsActive) respawnMenu.SetActive(true);
        else
        {
            string mySceneName = SceneManager.GetActiveScene().name;
            if (mySceneName.Contains("Inn"))
            {
                if (GDMContainer.myGDM.gameData.gameStart)
                {
                    innStartMenu.SetActive(true);
                    Time.timeScale = 0;
                }
                exitInn.SetActive(true);
            }
            else if (mySceneName.Contains("Shop"))
            {
                shopMenu.SetActive(true);
                exitShop.SetActive(true);                 
            }
            else if (mySceneName.Contains("Village"))
            {
                enterInn.SetActive(true);
                enterShop.SetActive(true);
            }
            else if(mySceneName == "Castle")
            {
                enterCellar.SetActive(true);
                enterPrison.SetActive(true);
                enterCastleInterior.SetActive(true);
            }
            else if(mySceneName == "Cellar")
            {
                exitCellar.SetActive(true);
            }
            else if(mySceneName == "Mountains")
            {
                enterMountain.SetActive(true);
            }
            else if(mySceneName == "Inside Mountain")
            {
                enterFinalBoss.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        string mySceneName = SceneManager.GetActiveScene().name;
        if (mySceneName == "FinalBoss" && GDMContainer.myGDM.gameData.dragIsDead)
        {
            sceneTeleportToCredits.SetActive(true);
        }

        escapeMenuActivation();
    }

    void escapeMenuActivation()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && escapeMenu.activeSelf)
        {
            escapeMenu.SetActive(false);

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !escapeMenu.activeSelf)
        {
            escapeMenu.SetActive(true);       
        }
    }
}
