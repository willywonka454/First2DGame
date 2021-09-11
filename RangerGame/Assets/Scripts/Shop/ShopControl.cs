using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ShopControl : MonoBehaviour
{

    public PlayerInventory playerInventory;

    public PlayerHP healthScript;

    public int heartCost;
    public Text heartCostText;

    public int healValue;
    public Text healValueText;

    public int arrowCost;
    public Text arrowCostText;

    // Start is called before the first frame update
    void Start()
    {
        heartCostText.text = "x" + heartCost;

        healValueText.text = "" + healValue;

        arrowCostText.text = "x" + arrowCost;       
    }

    public void buyHeart()
    {
        if (playerInventory.coins >= heartCost)
        {
            healthScript.heal(healValue);
            playerInventory.removeCoins(heartCost);
        }
    }

    public void buyArrow(int numArrows)
    {
        if (playerInventory.coins >= (numArrows * arrowCost))
        {
            playerInventory.addArrows(numArrows);
            playerInventory.removeCoins(numArrows * arrowCost);
        }
    }

    public void exitShop()
    {
        LevelControl.loadLevelByIndex(GlobalVars.indexOfPrevLevel);
    }
}
