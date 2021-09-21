using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCombat : MonoBehaviour
{

    public PetMovement petMovement;

    public GameObject enemy;

    public bool inAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        petMovement = GetComponent<PetMovement>();

        inAttackRange = false;

        StartCoroutine("damageTick");
    }

    // Update is called once per frame
    void Update()
    {
        enemy = petMovement.target.gameObject;

        if (enemy.tag != "Player")
        {            
            Transform enemyTransform = enemy.GetComponent<Transform>();

            float dist = Vector2.Distance(transform.position, enemyTransform.position);

            if (dist <= petMovement.stoppingDistance + 0.01f)
            {
                inAttackRange = true;
            }

            else
            {
                inAttackRange = false;
            }
        }
    }

    IEnumerator damageTick()
    {
        while(true)
        {
            if (inAttackRange && petMovement.mode == PetMovement.Mode.Attack)
            {
                if (enemy.tag == "Skeleton" || enemy.tag == "Wolf")
                {
                    SkeletonCombat skelCombat = enemy.GetComponent<SkeletonCombat>();

                    skelCombat.takeDmg(10);
                }

                if (enemy.tag == "Dragon")
                {
                    DragonCombat dragCombat = enemy.GetComponent<DragonCombat>();

                    dragCombat.takeDmg(10);
                }

                yield return new WaitForSeconds(0.5f);
            }

            else
            {
                yield return null;
            }
        }
    }
}
