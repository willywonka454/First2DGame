using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonCombat : MonoBehaviour
{
    public Rigidbody2D rb;

    public DragonWeapon weaponScript;

    public Health healthScript;
    public float hpThreshold = 0.25f;

    private bool fireMode = false;
    private float fireRate = 0.5f;

    public Vector3 chestSpawnPos = new Vector3(0.82f, -2.18f, 28.181f);
    public GameObject chestPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        weaponScript = GetComponent<DragonWeapon>();

        healthScript = GetComponent<Health>();

        StartCoroutine("FireFlameArcs");
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rb.velocity.x) <= 0.1f)
        {
            fireMode = true;
        }
        else
        {
            fireMode = false;
        }

        if(healthScript.hp <= healthScript.maxhp * hpThreshold)
        {
            fireRate = 0.1f;
        }
    }

    IEnumerator FireFlameArcs()
    {
        for(;;)
        {
            if(fireMode)
            {
                weaponScript.ShootFiveFireArcs();
                yield return new WaitForSeconds(fireRate);
            }
            else
            {
                yield return null;
            }
        }   
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Arrow")
        {
            takeDmg(5);
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

    public void die()
    {        
        GameObject chestObject = Instantiate(chestPrefab);
        chestObject.transform.position = chestSpawnPos;

        Openable chestScript = chestObject.GetComponentInChildren<Openable>();
        chestScript.valToDrop = 1000000;

        Destroy(transform.parent.gameObject);
        GDMContainer.myGDM.gameData.dragIsDead = true;
    }
}
