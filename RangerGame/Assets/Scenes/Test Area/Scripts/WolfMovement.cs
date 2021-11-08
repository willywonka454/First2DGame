using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : MonoBehaviour
{

    public MoveTowardsTarget moveTowardsTarget;
    public DetectRadius detectRadius;

    public Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {
        moveTowardsTarget = GetComponent<MoveTowardsTarget>();
        detectRadius = GetComponent<DetectRadius>();
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectRadius.targetDetected)
        {
            moveTowardsTarget.followTarget();
        }

        else
        {
            myRB.velocity = new Vector2(0, 0);
            moveBackAndForth();
        }
    }

    void moveBackAndForth()
    {

    }
}
