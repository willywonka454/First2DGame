using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{

    public float speed;
    public Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(rb.velocity.x, speed);
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Player") transform.position = startPos;
    }
}
