using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxhp;
    public int hp;

    public void heal(int healAmount)
    {
        int newHp = (hp + healAmount);
        if (newHp >= maxhp) hp = maxhp;
        else hp = newHp;
    }

    public void takeDmg(int dmg)
    {
        int newHp = (hp - dmg);
        if (newHp <= 0) hp = 0;
        else hp = newHp;
    }
}
