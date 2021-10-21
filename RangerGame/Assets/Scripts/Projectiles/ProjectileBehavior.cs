using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public GameObject owner;

    public GameObject FXPrefab;

    private Rigidbody2D rb;

    public float speed;

    public float angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        float xVelocity = 0;
        float yVelocity = 0;

        xVelocity = Mathf.Cos(angle) * speed;
        yVelocity = Mathf.Sin(angle) * speed;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xVelocity * Mathf.Sign(transform.localScale.x), yVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (FXPrefab != null)
        {
            GameObject cloneOfFXPrefab = Instantiate(FXPrefab, transform.position, transform.rotation);
            cloneOfFXPrefab.transform.localScale = transform.localScale;
        }
        Destroy(gameObject);
    }
}
