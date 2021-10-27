using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCombat : MonoBehaviour
{

    public CoinDropper coinDropper;

    public Health healthScript;

    public int xpReward = 10;

    // Start is called before the first frame update
    void Start()
    {
        healthScript = GetComponent<Health>();

        coinDropper = GetComponent<CoinDropper>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Arrow")
        {
            ProjectileBehavior arrow = collider.gameObject.GetComponent<ProjectileBehavior>();

            GameObject dmgSource = arrow.owner;

            int dmg = 0;

            if (dmgSource.tag == "Player")
            {
                dmg = arrow.owner.GetComponent<PlayerCombat>().attack;
            }

            takeDmg(dmg, dmgSource);
        }
    }

    public void takeDmg(int dmg)
    {
        healthScript.takeDmg(dmg);

        if (healthScript.hp <= 0)
        {
            die();
        }

    }

    public void takeDmg(int dmg, GameObject source)
    {
        if (source != null)
        {
            healthScript.takeDmg(dmg);            

            if (healthScript.hp <= 0)
            {
                PlayerXP playerXP = source.GetComponent<PlayerXP>();

                playerXP.setXP(playerXP.currXP + xpReward);

                die();
            }
        }

    }

    public void die()
    {
        Destroy(transform.parent.gameObject);
        coinDropper.dropCoin((healthScript.maxhp / 20) + 1);
    }
}
