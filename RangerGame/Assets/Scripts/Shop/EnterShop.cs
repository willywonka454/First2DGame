using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterShop : MonoBehaviour
{
    public void enterShop()
    {
        GlobalVars.indexOfPrevLevel = LevelControl.getCurrScene();

        GlobalVars.IDOfPrevExitPoint = -1;

        GlobalVars.playerDirX = 1;

        LevelControl.loadLevelByIndex(GlobalVars.indexOfShop);
    }
}
