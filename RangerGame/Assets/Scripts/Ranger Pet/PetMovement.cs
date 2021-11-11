using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    GameObject[] skeletons;
    GameObject[] wolves;
    GameObject[] dragons;
    GameObject[] allEnemies;

    public Transform target;
    public Transform player;

    public enum Mode
    {
        Attack,
        FollowPlayer
    }

    public Mode mode;

    void Start()
    {
        mode = Mode.FollowPlayer;

        GameObject[] entryPoints = GameObject.FindGameObjectsWithTag("EntryPoint");

        foreach (GameObject entryPoint in entryPoints)
        {
            EntryPoint entryPointScript = entryPoint.GetComponent<EntryPoint>();

            if (entryPointScript.ID == GlobalVars.IDOfPrevExitPoint)
            {
                transform.position = entryPoint.transform.position;
            }
        }
    }

    void Update()
    {
        skeletons = GameObject.FindGameObjectsWithTag("Skeleton");
        wolves = GameObject.FindGameObjectsWithTag("Wolf");
        dragons = GameObject.FindGameObjectsWithTag("Dragon");

        poolEnemies();

        if (allEnemies.Length != 0)
        {           
            mode = Mode.Attack;
            GameObject nearestEnemy = findNearestEnemy();
            target = nearestEnemy.transform;
        }

        else
        {
            mode = Mode.FollowPlayer;
            target = player;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

        }
    }

    GameObject findNearestEnemy()
    {
        GameObject nearest = null;

        for (int i = 0; i < allEnemies.Length; i++)
        {
            GameObject candidate = allEnemies[i];

            if (nearest == null)
            {
                nearest = candidate;
            }

            else
            {
                float canidateDist = Vector2.Distance(player.transform.position, allEnemies[i].transform.position);

                float nearestDist = Vector2.Distance(player.transform.position, nearest.transform.position);

                if (canidateDist < nearestDist)
                {
                    nearest = candidate;
                }
            }
        }

        return nearest;
    }

    void faceCorrectDirection()
    {
        
    }

    void poolEnemies()
    {
        allEnemies = new GameObject[skeletons.Length + wolves.Length + dragons.Length];

        int totalEnemies = 0;

        for (int i = 0; i < skeletons.Length; i++)
        {
            allEnemies[totalEnemies] = skeletons[i];
            totalEnemies++;
        }

        for (int i = 0; i < wolves.Length; i++)
        {
            allEnemies[totalEnemies] = wolves[i];
            totalEnemies++;
        }

        for (int i = 0; i < dragons.Length; i++)
        {
            allEnemies[totalEnemies] = dragons[i];
            totalEnemies++;
        }
    }
}
