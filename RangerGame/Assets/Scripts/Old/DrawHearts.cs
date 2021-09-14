using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHearts : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth playerHealthScript;
    public List<GameObject> heartsToDraw;
    public GameObject myPrefab;

    private float spaceBetween = 1f;
    private float startX = -15.5f;
    private float startY = 6.5f;

    // Start is called before the first frame update
    void Start()
    {
        float currX = startX;
        float currY = startY;

        playerHealthScript = player.GetComponent<PlayerHealth>();

        for (int newHeart = 0; newHeart < playerHealthScript.maxHearts; newHeart++)
        {
            heartsToDraw.Add(Instantiate(myPrefab, new Vector3(currX, currY, 0), Quaternion.identity));
            heartsToDraw[newHeart].transform.parent = transform;
            currX += spaceBetween;
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateHearts();        
    }

    void updateHearts()
    {
        int newNumHearts = playerHealthScript.numHearts;
        for(int currHeart = heartsToDraw.Count; currHeart > newNumHearts; currHeart--)
        {
            heartsToDraw[currHeart - 1].SetActive(false);
        }
    }
}
