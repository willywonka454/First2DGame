using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatV2 : Combat
{
    public Crossbow myCrossbow;

    public override void Start()
    {
        base.Start();

        myCrossbow = GetComponentInChildren<Crossbow>();
    }

    public override void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            myCrossbow.Shoot();
        }
    }
}
