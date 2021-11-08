using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRaycast : MonoBehaviour
{
    public float distance;
    public LayerMask mask;
    public bool targetDetected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool shootRay()
    {
        float hostDirection = Mathf.Sign(transform.localScale.x);
        Vector2 direction = new Vector2(hostDirection, 0);
        Vector2 origin = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, mask);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.tag);
            targetDetected = true;
            return true;
        }
        targetDetected = false;
        return false;
    }
}
