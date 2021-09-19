using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCombat : MonoBehaviour
{

    public PetMovement petMovement;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        petMovement = GetComponent<PetMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy = petMovement.target.gameObject;

        if (enemy.tag == "Skeleton")
        {

        }
    }

    IEnumerator damageTick()
    {
        yield return null;
    }
}
