using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private int dirY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dirY = -1;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed * dirY);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "SceneBoundary")
        {
            dirY *= -1;           
        }
    }
}
