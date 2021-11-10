using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCirclecast : DetectRaycast
{
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool shootRay()
    {
        if (displayRay) projectCircleCast();

        float hostDirection = Mathf.Sign(transform.localScale.x);
        Vector2 direction = new Vector2(hostDirection, 0);
        Vector2 origin = shootPoint.position;

        RaycastHit2D hit = Physics2D.CircleCast(origin, radius, direction, distance, mask);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.tag + ". This is from circle cast.");
            return true;
        }
        return false;
    }

    public void projectCircleCast()
    {
        GameObject circleProjection = new GameObject();
        circleProjection.name = "Circle Cast Projection";
        circleProjection.transform.position = shootPoint.transform.position;               

        for (float angle = 0; angle < (2 * Mathf.PI); angle += (Mathf.PI / 12))
        {
            float x = shootPoint.transform.position.x + (radius * Mathf.Cos(angle));
            float y = shootPoint.transform.position.y + (radius * Mathf.Sin(angle));
            Vector2 pos = new Vector2(x, y);

            GameObject greenBlobPrefab = Resources.Load<GameObject>("Green Blob");
            GameObject radiusMarker = Instantiate(greenBlobPrefab, pos, Quaternion.identity);
            radiusMarker.transform.localScale = new Vector2(0.2f, 0.2f);
            radiusMarker.transform.parent = circleProjection.transform;                       
        }

        RaycastProjection myScript = circleProjection.AddComponent<RaycastProjection>();
        myScript.origin = shootPoint.transform.position;
        myScript.maxDist = distance;

        Rigidbody2D projectionRB = circleProjection.AddComponent<Rigidbody2D>();
        float projectionDirX = Mathf.Sign(transform.localScale.x);
        projectionRB.gravityScale = 0;
        projectionRB.velocity = new Vector2(projectionDirX * 15, 0);
    }
}
