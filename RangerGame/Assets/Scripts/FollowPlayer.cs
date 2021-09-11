using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(player.transform.position.x - 2.75f, player.transform.position.y - 0.69f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(player.transform.localScale.x, player.transform.localScale.y, transform.localScale.z);

        if (transform.localScale.x < 0f) 
        {
            transform.position = new Vector3(player.transform.position.x + 2.75f, player.transform.position.y - 0.69f, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x - 2.75f, player.transform.position.y - 0.69f, transform.position.z);
        }        
    }
}
