using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclecastProjection : MonoBehaviour
{

    public Vector2 origin;
    public float maxDist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, origin) >= maxDist)
        {
            Destroy(gameObject);
        }
    }
}
