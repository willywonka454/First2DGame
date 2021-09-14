using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTest : MonoBehaviour
{

    public Image heartImage;
    public PlayerHealth playerHPScript;

    private List<Image> heartsToDraw = new List<Image>();

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
        for(int i = 0; i < heartsToDraw.Count; i++)
        {
            Destroy(heartsToDraw[i].gameObject);
        }

        heartsToDraw.Clear();
    }

    void fillHeartsToDraw(int numHearts)
    {
        float spaceBetween = 25;

        heartImage.enabled = true;

        for (int i = 0; i < numHearts; i++)
        {
            heartsToDraw.Add(Instantiate(heartImage, transform));
            float newX = heartImage.rectTransform.transform.position.x + (i * spaceBetween);
            float newY = heartImage.rectTransform.transform.position.y;
            heartsToDraw[i].rectTransform.transform.position = new Vector2(newX, newY);
            heartsToDraw[i].enabled = true;
        }

        heartImage.enabled = false;
    }
}
