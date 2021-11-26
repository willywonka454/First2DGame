using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHealth : MonoBehaviour
{
	public int myHP;
	public int myMaxHP;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void takeDamage(int damageAmount)
	{
		int tempHP = myHP - damageAmount;
		if (tempHP < 0) myHP = 0;
		else myHP = tempHP;
	}

	public void heal(int healAmount)
	{
		int tempHP = myHP + healAmount;
		if (tempHP > myMaxHP) myHP = myMaxHP;
		else myHP = tempHP;
	}
}
