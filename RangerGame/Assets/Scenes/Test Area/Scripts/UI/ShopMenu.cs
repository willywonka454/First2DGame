using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    [Header ("Player related")]
    public GameObject player;
    public PlayerInventoryV2 playerInventory;
    public MyHealth playerHealth;

    [Header("Arrows")]
    public int arrowPrice = 1;
    public TMP_Text arrowPriceText;
    public Button buyArrowButton1;
    public Button buyArrowButton5;

    [Header("Health Units")]
    public int healthUnitPrice = 5;
    public int healthUnitHP = 20;
    public TMP_Text healthUnitPriceText;
    public Button buyHealthUnitButton;

    [Header("Pet")]
    public GameObject petPrefab;
    public Vector2 petSpawnLoc;
    public int petPrice = 10;
    public bool hasBoughtPet;
    public TMP_Text petPriceText;
    public Button buyPetButton;

    // Start is called before the first frame update
    void Start()
    {
        // Find the player.
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerInventory = player.GetComponent<PlayerInventoryV2>();
            playerHealth = player.GetComponent<MyHealth>();
        }

        // Initialize price text meshes.
        arrowPriceText.text = "x" + arrowPrice;
        healthUnitPriceText.text = "x" + healthUnitPrice;
        petPriceText.text = "x" + petPrice;

        // Initialize button actions.
        buyArrowButton1.onClick.AddListener(() => buyArrows(1));
        buyArrowButton5.onClick.AddListener(() => buyArrows(5));
        buyHealthUnitButton.onClick.AddListener(() => buyHealthUnit(1));
        buyPetButton.onClick.AddListener(() => buyPet());
    }

    // Update is called once per frame
    void Update()
    {
        // Make buttons uninteractable if player cannot buy.
        updateButton(buyArrowButton1, arrowPrice);
        updateButton(buyArrowButton5, arrowPrice * 5);

        // Special case for buyHealthUnitButton
        if (!playerCanBuy(healthUnitPrice) || playerHealth.myHP >= playerHealth.myMaxHP)
        {
            buyHealthUnitButton.interactable = false;
        }
        else buyHealthUnitButton.interactable = true;

        // Special case for buyPetButton.
        if (!playerCanBuy(petPrice) || hasBoughtPet || GDMContainer.myGDM.gameData.UIInteraction == false)
        {
            buyPetButton.interactable = false;
        }
        else buyPetButton.interactable = true;
    }

    void OnEnable()
    {
        // Do not let player fire arrows in the shop.
        GDMContainer.myGDM.gameData.playerControls = false;

        // Update my hasBoughtPet bool.
        hasBoughtPet = GDMContainer.myGDM.gameData.hasBoughtPet;
    }

    void OnDisable()
    {
        // When leaving the shop scene, let player fire arrows again.
        GDMContainer.myGDM.gameData.playerControls = true;

        // Update gameData's hasBoughtPet bool.
        GDMContainer.myGDM.gameData.hasBoughtPet = hasBoughtPet;
    }

    public void updateButton(Button myButton, int itemPrice)
    {
        if (!playerCanBuy(itemPrice) || GDMContainer.myGDM.gameData.UIInteraction == false)
        {
            myButton.interactable = false;
        }
        else myButton.interactable = true;
    }

    public bool playerCanBuy(int price)
    {
        if (player != null && playerInventory.coins >= price) return true;
        else return false;
    }

    public void buyHealthUnit(int amount)
    {
        if (playerCanBuy(healthUnitPrice * amount))
        {
            playerHealth.heal(healthUnitHP * amount);
            playerInventory.removeCoins(healthUnitPrice * amount);
        }
    }

    public void buyArrows(int amount)
    {
        if (playerCanBuy(arrowPrice * amount))
        {
            playerInventory.addArrows(amount);
            playerInventory.removeCoins(arrowPrice * amount);
        }
    }

    public void buyPet()
    {
        if (playerCanBuy(petPrice) && !hasBoughtPet)
        {
            playerInventory.removeCoins(petPrice);
            Instantiate(petPrefab, petSpawnLoc, Quaternion.identity);
            hasBoughtPet = true;
        }
    }
}
