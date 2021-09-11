using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public int arrows;
    public int coins;

    // Start is called before the first frame update
    void Start()
    {
        arrows = GlobalVars.playerArrows;
        coins = GlobalVars.playerCoins;
    }

    public void addArrows(int number)
    {
        arrows += number;

        GlobalVars.playerArrows = arrows;
    }

    public void removeArrows(int number)
    {
        int newArrows = arrows - number;

        if (newArrows <= 0) arrows = 0;

        else arrows = newArrows;

        GlobalVars.playerArrows = arrows;
    }

    public void addCoins(int number)
    {
        coins += number;

        GlobalVars.playerCoins = coins;
    }

    public void removeCoins(int number)
    {
        int newCoins = coins - number;

        if (newCoins < 0) return;

        else coins = newCoins;

        GlobalVars.playerCoins = coins;
    }
}
