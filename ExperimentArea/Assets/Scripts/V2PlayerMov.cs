using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2PlayerMov : MonoBehaviour
{
    Rigidbody2D rb;

    float horizontalInput;
    bool justJumped = false;

    public float MovementSpeed = 1;
    public float JumpForce = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            justJumped = true;
        }               
    }

    void FixedUpdate()
    {
        if (justJumped)
        {
            justJumped = false;
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        transform.position += new Vector3(horizontalInput, 0, 0) * Time.deltaTime * MovementSpeed;       
    }
}
