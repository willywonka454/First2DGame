using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    public bool triedLookingForTarget;
    public string targetTag = "Player";
    public GameObject target;
    public Vector2 targetPos;

    public float speed;
    public float stopDistance;
    public float dist;

    public Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag(targetTag);

        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null && !triedLookingForTarget)
        {
            target = GameObject.FindWithTag(targetTag);
            triedLookingForTarget = true;
        }
    }

    public void followTarget()
    {
        if (target != null)
        {
            targetPos = target.transform.position;

            dist = Vector2.Distance(targetPos, transform.position);

            if (dist > stopDistance)
            {
                float xDist = Mathf.Abs(targetPos.x - transform.position.x);
                float yDist = Mathf.Abs(targetPos.y - transform.position.y);

                float angle = Mathf.Asin(yDist / dist);

                float xVel = speed * Mathf.Cos(angle);
                float yVel = speed * Mathf.Sin(angle);

                if (targetPos.x < transform.position.x) xVel *= -1;
                if (targetPos.y < transform.position.y) yVel *= -1;

                myRB.velocity = new Vector2(xVel, yVel);                
            }
            
            else
            {
                myRB.velocity = new Vector2(0, 0);
            }

            faceTarget();
        }
    }

    public void faceTarget()
    {
        if (target != null)
        {
            float newDirX = Mathf.Abs(transform.localScale.x);

            if (targetPos.x <= transform.position.x)
            {
                newDirX *= -1;
            }

            transform.localScale = new Vector2(newDirX, transform.localScale.y);
        }
    }
}
