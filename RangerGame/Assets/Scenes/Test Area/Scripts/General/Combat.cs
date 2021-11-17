using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public MyHealth myHealth;

    public int attackDamage;

    // Start is called before the first frame update
    public virtual void Start()
    {
        myHealth = GetComponent<MyHealth>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {

    }

    public virtual void takeDamage(int damageAmount)
    {
        myHealth.takeDamage(damageAmount);
        if (myHealth.myHP <= 0) die();
    }

    public virtual void heal(int healAmount)
    {
        myHealth.heal(healAmount);
    }

    public virtual void die()
    {
        Destroy(gameObject);
    }
}
