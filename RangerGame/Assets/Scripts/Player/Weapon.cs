using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform shootPoint;

    public GameObject projectile;

    public GameObject player;

    private float weaponDirX;

    public void Shoot()
    {
        GameObject newProjectile = Instantiate(projectile, shootPoint.position, shootPoint.rotation);

        weaponDirX = player.transform.localScale.x;

        newProjectile.transform.localScale = new Vector3(weaponDirX, 1, 1);

        ProjectileBehavior projectileScript = newProjectile.GetComponent<ProjectileBehavior>();

        projectileScript.owner = player;
    }
}
