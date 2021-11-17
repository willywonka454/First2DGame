using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryV2 : MonoBehaviour
{
    public int arrows;
    public int coins;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void addArrows(int number)
    {
        arrows += number;
    }

    public void removeArrows(int number)
    {
        int newArrows = arrows - number;
        if (newArrows <= 0) arrows = 0;
        else arrows = newArrows;
    }

    public void addCoins(int number)
    {
        coins += number;
    }

    public void removeCoins(int number)
    {
        int newCoins = coins - number;
        if (newCoins < 0) return;
        else coins = newCoins;
    }
}
