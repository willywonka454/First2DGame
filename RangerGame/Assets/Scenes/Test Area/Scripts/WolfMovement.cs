using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : MonoBehaviour
{

    public MoveTowardsTarget moveTowardsTarget;
    public DetectRadius detectRadius;
    public DetectCirclecast detectCirclecast;

    public Rigidbody2D myRB;

    public bool followingTarget;

    // Start is called before the first frame update
    void Start()
    {
        moveTowardsTarget = GetComponent<MoveTowardsTarget>();
        detectRadius = GetComponent<DetectRadius>();
        detectCirclecast = GetComponent<DetectCirclecast>();
        myRB = GetComponent<Rigidbody2D>();

        StartCoroutine("checkFieldOfVision");
    }

    // Update is called once per frame
    void Update()
    {
        if (followingTarget)
        {
            moveTowardsTarget.followTarget();      
        }

        else
        {
            myRB.velocity = new Vector2(0, 0);
            moveBackAndForth();
        }
    }

    IEnumerator checkFieldOfVision()
    {
        while(true)
        {
            bool canSeeTarget;

            if (followingTarget)
            {
                canSeeTarget = detectRadius.targetDetected();
            }

            else
            {
                canSeeTarget = detectCirclecast.shootRay();
            }

            if (canSeeTarget) followingTarget = true;

            else followingTarget = false;

            yield return new WaitForSeconds(1f);
        }
    }

    public void moveBackAndForth()
    {
        float myDirection = Mathf.Sign(transform.localScale.x);
        myRB.velocity = new Vector2(myDirection * moveTowardsTarget.speed, myRB.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "SceneBoundary" && !followingTarget)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
