using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class FirstTest : MonoBehaviour
{

    public TMP_Text myText;

    public Rigidbody2D rb;

    public float speed = 12f;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<TMP_Text>();
        myText.color = new Vector4(myText.color.r, myText.color.g, myText.color.g, 0.5f);

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
