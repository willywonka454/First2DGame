using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    public Camera cam;

    public bool acceptingScrollInput = true;

    public float scale = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (acceptingScrollInput)
        {
            float scrollDirection = Input.mouseScrollDelta.y;

            if (scrollDirection >= 0.01f)
            {
                zoomIn(scale);
            }

            else if (scrollDirection <= -0.01f)
            {
                zoomOut(scale);
            }
        }
    }

    public void zoom(float zoomAmount)
    {
        cam.orthographicSize += zoomAmount;
    }

    public void zoomIn(float zoomAmount)
    {
        cam.orthographicSize -= zoomAmount;
    }

    public void zoomOut(float zoomAmount)
    {
        cam.orthographicSize += zoomAmount;
    }
}
