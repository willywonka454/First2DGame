using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private Transform playerTrans;

    private bool AtLeftBorder;
    private bool AtRightBorder;
    private bool AtUpBorder;
    private bool AtDownBorder;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (AtLeftBorder && AtUpBorder)
        {
            if(playerTrans.position.x > transform.position.x)
            {
                AtLeftBorder = false;
            }

            if(playerTrans.position.y < transform.position.y)
            {
                AtUpBorder = false;
            }
        }

        else if (AtLeftBorder && AtDownBorder)
        {
            if (playerTrans.position.x > transform.position.x)
            {
                AtLeftBorder = false;
            }

            if (playerTrans.position.y > transform.position.y)
            {
                AtDownBorder = false;
            }
        }

        else if (AtRightBorder && AtUpBorder)
        {
            if (playerTrans.position.x < transform.position.x)
            {
                AtRightBorder = false;
            }

            if (playerTrans.position.y < transform.position.y)
            {
                AtUpBorder = false;
            }
        }

        else if (AtRightBorder && AtDownBorder)
        {
            if (playerTrans.position.x < transform.position.x)
            {
                AtRightBorder = false;
            }

            if (playerTrans.position.y > transform.position.y)
            {
                AtDownBorder = false;
            }
        }

        else if (AtLeftBorder)
        {
            if (playerTrans.position.x > transform.position.x)
            {
                AtLeftBorder = false;
            }

            FollowPlayerY();
        }

        else if (AtRightBorder)
        {
            if (playerTrans.position.x < transform.position.x)
            {
                AtRightBorder = false;
            }

            FollowPlayerY();
        }

        else if (AtUpBorder)
        {
            if (playerTrans.position.y < transform.position.y)
            {
                AtUpBorder = false;
            }

            FollowPlayerX();
        }

        else if (AtDownBorder)
        {
            if (playerTrans.position.y > transform.position.y)
            {
                AtDownBorder = false;
            }

            FollowPlayerX();
        }

        else
        {
            FollowPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "InvisWallLeft")
        {
            AtLeftBorder = true;         
        }

        if (col.gameObject.tag == "InvisWallRight")
        {
            AtRightBorder = true;
        }

        if (col.gameObject.tag == "InvisWallUp")
        {
            AtUpBorder = true;
        }

        if (col.gameObject.tag == "InvisWallDown")
        {
            AtDownBorder = true;
        }
    }

    void Halt(Vector3 stopPosition)
    {
        transform.position = new Vector3(stopPosition.x, stopPosition.y, stopPosition.z);
    }

    void FollowPlayerX()
    {
        transform.position = new Vector3(playerTrans.position.x, transform.position.y, transform.position.z);
    }

    void FollowPlayerY()
    {
        transform.position = new Vector3(transform.position.x, playerTrans.position.y, transform.position.z);
    }

    void FollowPlayer()
    {
        transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y, transform.position.z);
    }
}
