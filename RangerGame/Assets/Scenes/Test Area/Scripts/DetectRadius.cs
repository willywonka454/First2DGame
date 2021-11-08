using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class DetectRadius : MonoBehaviour
{

    public Vector2 center;
    public float radius = 5f;

    public string targetTag = "Player";
    public GameObject target;

    public TMP_Text indicator;
    public bool targetDetected = false;

    public GameObject DballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag(targetTag);

        if (indicator != null) indicator.gameObject.SetActive(true);

        for (float angle = 0; angle < (2 * Mathf.PI); angle += (Mathf.PI / 12))
        {
            float x = center.x + (radius * Mathf.Cos(angle));
            float y = center.y + (radius * Mathf.Sin(angle));

            Vector2 pos = new Vector2(x, y);

            var radiusMarker = Instantiate(DballPrefab, pos, Quaternion.identity);
            radiusMarker.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        center = transform.position;

        Vector2 target_pos = target.GetComponent<Transform>().position;

        if (Vector2.Distance(center, target_pos) <= radius)
        {
            targetDetected = true;
        }
        
        else
        {
            targetDetected = false;
        }

        if (indicator != null)
        {
            if (targetDetected)
            {
                indicator.text = "Player detected: true";
                indicator.color = Color.green;
            }

            else
            {
                indicator.text = "Player detected: false";
                indicator.color = Color.red;
            }

            indicator.transform.position = new Vector2(center.x + 5, center.y + 5);
        }
    }
}
