using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{

    public Text myText;

    public PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInventory != null) myText.text = "x" + playerInventory.coins;
        else myText.text = "x" + GlobalVars.playerCoins;
    }
}
