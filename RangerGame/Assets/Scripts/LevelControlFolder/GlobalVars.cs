using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Reflection;

public static class GlobalVars
{
    public static int IDOfPrevExitPoint = -2;
    public static EntryPoint entryPoint;

    public static int indexOfPrevLevel = 0;
    public static int indexOfShop = 17;

    public static int playerCoins = 5;
    public static int playerArrows = 100;
    public static int playerHP = 100;
    public static float playerDirX = 1;

    public static bool acceptingUserInput = true;

    public static bool dragonDead = false;
    public static bool playerDead = false;
    public static bool playerInVillage = true;

    public static void reset()
    {
        IDOfPrevExitPoint = -2;
        indexOfPrevLevel = 0;
        indexOfShop = 17;

        playerCoins = 5;
        playerArrows = 10;
        playerHP = 100;

        playerDirX = 1;

        acceptingUserInput = true;

        dragonDead = false;
        playerDead = false;
        playerInVillage = false;
    }
}
