using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarForEnemy : MonoBehaviour
{

    public GameObject heartImage;
    public EnemyHealth playerHPScript;

    private List<GameObject> heartsToDraw = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        fillHeartsToDraw(playerHPScript.maxHearts);
    }

    // Update is called once per frame
    void Update()
    {
        updateHeartsToDraw();
    }

    void updateHeartsToDraw()
    {
        if (playerHPScript.numHearts != heartsToDraw.Count)
        {
            clearHeartsToDraw();
            fillHeartsToDraw(playerHPScript.numHearts);
        }
    }

    void clearHeartsToDraw()
    {
        for (int i = 0; i < heartsToDraw.Count; i++)
        {
            Destroy(heartsToDraw[i].gameObject);
        }

        heartsToDraw.Clear();
    }

    void fillHeartsToDraw(int numHearts)
    {
        float spaceBetween = 0.25f;

        heartImage.SetActive(true);

        for (int i = 0; i < numHearts; i++)
        {
            heartsToDraw.Add(Instantiate(heartImage, transform));
            float newX = heartImage.transform.position.x + (i * spaceBetween);
            float newY = heartImage.transform.position.y;
            heartsToDraw[i].transform.position = new Vector2(newX, newY);
        }

        heartImage.SetActive(false);
    }
}
