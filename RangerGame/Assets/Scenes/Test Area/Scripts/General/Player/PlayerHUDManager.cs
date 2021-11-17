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

    [Header("UI related")]
    public TMP_Text playerHealthText;
    public TMP_Text playerArrowsText;
    public TMP_Text playerCoinsText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<MyHealth>();
        playerInventory = player.GetComponent<PlayerInventoryV2>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "" + playerHealth.myHP;
        playerArrowsText.text = "x" + playerInventory.arrows;
        playerCoinsText.text = "x" + playerInventory.coins;
    }
}
