using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public PlayerHP healthScript;

    public Weapon weaponScript;

    public PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        healthScript = GetComponent<PlayerHP>();

        weaponScript = GetComponentInChildren<Weapon>();

        playerInventory = GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && playerInventory.arrows > 0)
        {
            weaponScript.Shoot();
            playerInventory.removeArrows(1);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            healthScript.takeDmg(20);
        }
        
        if(collider.gameObject.tag == "Fireball")
        {
            healthScript.takeDmg(20);
        }

        if(collider.gameObject.tag == "Coin")
        {
            Coin coinScript = collider.gameObject.GetComponent<Coin>();
            playerInventory.addCoins(coinScript.value);
            Destroy(collider.gameObject);
        }

        if (healthScript.hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}