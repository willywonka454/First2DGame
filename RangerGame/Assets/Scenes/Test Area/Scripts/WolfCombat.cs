using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCombat : MonoBehaviour
{

    public WolfMovement wolfMovement;
    public DetectRadius attackRadius;
    public float attackSpeed;
    public bool attacking;

    // Start is called before the first frame update
    void Start()
    {
        wolfMovement = GetComponent<WolfMovement>();

        DetectRadius[] radii = GetComponents<DetectRadius>();

        foreach(DetectRadius r in radii) 
        {
            if (r.myName == "attackRadius") attackRadius = r;
        }

        StartCoroutine("executeAttacksOnPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        if (wolfMovement.followingTarget && attackRadius.targetDetected())
        {
            attacking = true;
        }

        else
        {
            attacking = false;
        }
    }

    public void attackPlayer()
    {
        PlayerCombat playerCombat = attackRadius.target.GetComponent<PlayerCombat>();

        playerCombat.takeDmg(10);
    }

    IEnumerator executeAttacksOnPlayer()
    {
        while (true)
        {
            if (attacking)
            {
                attackPlayer();
                yield return new WaitForSeconds(attackSpeed);
            }

            yield return null;
        }
    }
}
