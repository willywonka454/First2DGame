using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxhp = 100;
    public int hp;

    void Start()
    {
        hp = GlobalVars.playerHP;
    }

    public void heal(int healAmount)
    {
        int newHp = (hp + healAmount);

        if (newHp >= maxhp) hp = maxhp;

        else hp = newHp;

        GlobalVars.playerHP = hp;
    }

    public void takeDmg(int dmg)
    {
        int newHp = (hp - dmg);

        if (newHp <= 0) hp = 0;

        else hp = newHp;

        GlobalVars.playerHP = hp;
    }
}
