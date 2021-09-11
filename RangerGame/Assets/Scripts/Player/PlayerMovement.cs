using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private GameObject[] entryPoints;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        transform.localScale = new Vector3(transform.localScale.x * GlobalVars.playerDirX, transform.localScale.y, transform.localScale.z);

        entryPoints = GameObject.FindGameObjectsWithTag("EntryPoint");

        foreach (GameObject entryPoint in entryPoints)
        {
            EntryPoint entryPointScript = entryPoint.GetComponent<EntryPoint>();

            if (entryPointScript.ID == GlobalVars.IDOfPrevExitPoint)
            {
                transform.position = entryPoint.transform.position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(dirX * speed, dirY * speed);

        if (dirX < 0f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1f, transform.localScale.y, transform.localScale.z);
        }
        else if (dirX > 0f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = transform.localScale;
        }

        UpdateAnimationState();
    }

    void UpdateAnimationState()
    {
        if (Mathf.Abs(rb.velocity.x) > 0.01f || Mathf.Abs(rb.velocity.y) > 0.01f)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }
}
