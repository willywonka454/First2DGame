using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCombat : Combat
{
    public CoinDropper coinDropper;

    public WolfMovement wolfMovement;
    public DetectRadius attackRadius;
    public float attackSpeed;
    public bool attacking;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        coinDropper = GetComponent<CoinDropper>();

        wolfMovement = GetComponent<WolfMovement>();

        DetectRadius[] radii = GetComponents<DetectRadius>();

        foreach(DetectRadius r in radii) 
        {
            if (r.myName == "attackRadius") attackRadius = r;
        }

        StartCoroutine("executeAttacksOnPlayer");
    }

    // Update is called once per frame
    public override void Update()
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

    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            /*ProjectileBehavior projectile = col.gameObject.GetComponent<ProjectileBehavior>();
            GameObject owner = projectile.owner;
            int ownerAttackDamage = owner.GetComponent<Combat>().attackDamage;
            takeDamage(ownerAttackDamage);*/
            takeDamage(20);
        }
    }

    public override void die()
    {
        coinDropper.dropCoin((myHealth.myMaxHP / 20) + 1);
        base.die();
    }

    public void attackPlayer()
    {
        Combat playerCombat = attackRadius.target.GetComponent<Combat>();

        playerCombat.takeDamage(attackDamage);
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
