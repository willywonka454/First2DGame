using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRaycast : MonoBehaviour
{
    public Transform shootPoint;
    public float distance;
    public LayerMask mask;
    public bool targetDetected;

    // Start is called before the first frame update
    void Start()
    {
        //setUpShootPointDisplay();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual bool shootRay()
    {
        projectRaycast();

        float hostDirection = Mathf.Sign(transform.localScale.x);
        Vector2 direction = new Vector2(hostDirection, 0);
        Vector2 origin = shootPoint.transform.position;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, mask);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.tag + ". This is from ray cast.");
            return true;
        }
        return false;
    }

    public void projectRaycast()
    {
        GameObject rayProjection = new GameObject();
        rayProjection.name = "Ray Cast Projection";
        rayProjection.transform.position = shootPoint.transform.position; 
        
        GameObject greenBlobPrefab = Resources.Load<GameObject>("Green Blob");
        GameObject radiusMarker = Instantiate(greenBlobPrefab, rayProjection.transform.position, Quaternion.identity);
        radiusMarker.transform.localScale = new Vector2(0.2f, 0.2f);
        radiusMarker.transform.parent = rayProjection.transform;                

        RaycastProjection myScript = rayProjection.AddComponent<RaycastProjection>();
        myScript.origin = shootPoint.transform.position;
        myScript.maxDist = distance;

        Rigidbody2D myRB = rayProjection.AddComponent<Rigidbody2D>();
        float projectionDirX = Mathf.Sign(transform.localScale.x);
        myRB.gravityScale = 0;
        myRB.velocity = new Vector2(projectionDirX * 15, 0);
    }

    public void setUpShootPointDisplay()
    {
        GameObject greenBlobPrefab = Resources.Load<GameObject>("Green Blob");
        GameObject spMarker = Instantiate(greenBlobPrefab, shootPoint.position, Quaternion.identity);
        spMarker.transform.localScale = new Vector2(0.3f, 0.3f);
        spMarker.transform.parent = shootPoint.transform;
    }
}
