using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    GameObject[] skeletons;

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
    }

    void Update()
    {
        skeletons = GameObject.FindGameObjectsWithTag("Skeleton");

        if (skeletons.Length != 0)
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
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    GameObject findNearestEnemy()
    {
        GameObject nearest = null;

        for (int i = 0; i < skeletons.Length; i++)
        {
            GameObject candidate = skeletons[i];

            if (nearest == null)
            {
                nearest = candidate;
            }

            else
            {
                float canidateDist = Vector2.Distance(player.transform.position, skeletons[i].transform.position);

                float nearestDist = Vector2.Distance(player.transform.position, nearest.transform.position);

                if (canidateDist < nearestDist)
                {
                    nearest = candidate;
                }
            }
        }

        return nearest;
    }
}
