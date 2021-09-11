using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public int dirX;

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
        if (col.gameObject.tag == "InvisWall")
        {
            StartCoroutine("StopAndChangeDirection");
        }
    }

    IEnumerator StopAndChangeDirection()
    {
        float oldSpeed = speed;

        speed = 0;

        yield return new WaitForSeconds(1.5f);

        dirX *= -1;

        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

        speed = oldSpeed;
    }
}
