using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRB;

    // Start is called before the first frame update
    public virtual  void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }
}
