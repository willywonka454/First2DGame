using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobaCamera : MonoBehaviour
{
    public float topBorder;
    public float botBorder;
    public float leftBorder;
    public float rightBorder;

    public Vector3 mousePos;

    public Camera cam;
    public Rigidbody2D camRbody;
    public float camSpeed;
    public float offsetX;
    public float offsetY;

    bool movingCamUp;
    bool movingCamDown;
    bool movingCamLeft;
    bool movingCamRight;
    bool movingCam;
    bool defaultLock;
    bool customLock;
    bool camLocked;

    public GameObject player;
    public Transform playerTrans;

    // Start is called before the first frame update
    void Start()
    {       
        camRbody = cam.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTrans = player.transform;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        movingCamUp = mousePos.y > (Screen.height * topBorder);
        movingCamDown = mousePos.y < (Screen.height * botBorder);
        movingCamLeft = mousePos.x < (Screen.width * leftBorder);
        movingCamRight = mousePos.x > (Screen.width * rightBorder);
        movingCam = (movingCamUp || movingCamDown || movingCamLeft || movingCamRight);

        camLocked = (defaultLock || customLock);

        // User input
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (customLock) customLock = false;

            else
            {
                customLock = true;
                defaultLock = false;

                if (playerTrans != null)
                {
                    offsetX = cam.GetComponent<Transform>().position.x - playerTrans.position.x;
                    offsetY = cam.GetComponent<Transform>().position.y - playerTrans.position.y;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (defaultLock) defaultLock = false;

            else
            {
                defaultLock = true;
                customLock = false;

                offsetX = 0;
                offsetY = 0;
            }
        }

        // Camera conditions
        if (!camLocked)
        {
            if (movingCamUp) camRbody.velocity = new Vector2(camRbody.velocity.x, camSpeed);

            if (movingCamDown) camRbody.velocity = new Vector2(camRbody.velocity.x, camSpeed * -1);

            if (movingCamLeft) camRbody.velocity = new Vector2(camSpeed * -1, camRbody.velocity.y);

            if (movingCamRight) camRbody.velocity = new Vector2(camSpeed, camRbody.velocity.y);

            if (Input.GetKey(KeyCode.Space))
            {
                offsetX = 0;
                offsetY = 0;

                followPlayer();
            }
        }

        if (!movingCam && !camLocked) camRbody.velocity = new Vector2(0, 0);

        if (camLocked) followPlayer();
    }

    public void followPlayer()
    {
        if (playerTrans != null)
        {
            transform.position = new Vector3(playerTrans.position.x + offsetX, playerTrans.position.y + offsetY, transform.position.z);
        }        
    }
        
}
