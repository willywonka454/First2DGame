using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCombat : MonoBehaviour
{

    public CoinDropper coinDropper;

    public Health healthScript;

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
            healthScript.takeDmg(20);
        }

        if (healthScript.hp <= 0)
        {
            Destroy(transform.parent.gameObject);
            coinDropper.dropCoin((healthScript.maxhp / 20) + 1);
        }
    }
}
