using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWeapon : MonoBehaviour
{
    public Transform shootPoint;

    public GameObject projectile;

    public GameObject weaponUser;

    public float angle;

    private float weaponDirX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void ShootFiveFireArcs()
    {
        angle = 0f;

        Shoot();

        angle = (Mathf.PI * 11) / 6;

        Shoot();

        angle = (Mathf.PI * 5) / 3;

        Shoot();

        angle = (Mathf.PI * 1) / 6;

        Shoot();

        angle = (Mathf.PI * 1) / 3;

        Shoot();
    }

    void Shoot()
    {
        weaponDirX = Mathf.Sign(weaponUser.transform.localScale.x);

        GameObject newProjectile = Instantiate(projectile, shootPoint.position, shootPoint.rotation);

        newProjectile.transform.localScale = new Vector3(weaponDirX * newProjectile.transform.localScale.x, newProjectile.transform.localScale.y, newProjectile.transform.localScale.z);

        ProjectileBehavior projectileScript = newProjectile.GetComponent<ProjectileBehavior>();

        projectileScript.angle = angle;
    }
}
