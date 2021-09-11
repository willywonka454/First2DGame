using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private int dirX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dirX = -1;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "SceneBoundary")
        {
            dirX *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
