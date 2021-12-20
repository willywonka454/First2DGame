using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : SpecialLocationEnterable
{
    public CoinDropper myCoinDropper;
    public int valToDrop;

    public override void Start()
    {
        base.Start();

        myCoinDropper = GetComponent<CoinDropper>();
    }

    public override void myAction()
    {
        myCoinDropper.dropCoin(valToDrop);
        Destroy(transform.parent.gameObject);        
    }
}
