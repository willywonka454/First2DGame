using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class PlayerHUDManager : MonoBehaviour
{
    [Header("Player related")]
    public GameObject player;
    public MyHealth playerHealth;
    public PlayerInventoryV2 playerInventory;
    public bool hasSetHPOnDeath;

    [Header("UI related")]
    public TMP_Text playerHealthText;
    public TMP_Text playerArrowsText;
    public TMP_Text playerCoinsText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<MyHealth>();
            playerInventory = player.GetComponent<PlayerInventoryV2>();
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            playerHealthText.text = "" + playerHealth.myHP;
            playerArrowsText.text = "x" + playerInventory.arrows;
            playerCoinsText.text = "x" + playerInventory.coins;
        }

        else if(player == null && !hasSetHPOnDeath)
        {
            playerHealthText.text = "" + (0);
            hasSetHPOnDeath = true;
        }
    }
}
