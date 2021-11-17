using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class DetectRadius : MonoBehaviour
{
    public string myName;

    public Vector2 center;
    public float radius = 5f;

    public bool triedLookingForTarget;
    public string targetTag = "Player";
    public GameObject target;

    public bool display;
    public TMP_Text indicator;
    public GameObject DballPrefab;
    public int degreeInterval;
    public float dballSize;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag(targetTag);

        if (display)
        {
            if (indicator != null) indicator.gameObject.SetActive(true);

            for (float angle = 0; angle < (2 * Mathf.PI); angle += (Mathf.PI / degreeInterval))
            {
                float x = center.x + (radius * Mathf.Cos(angle));
                float y = center.y + (radius * Mathf.Sin(angle));

                Vector2 pos = new Vector2(x, y);

                if (DballPrefab != null)
                {
                    var radiusMarker = Instantiate(DballPrefab, pos, Quaternion.identity);
                    radiusMarker.transform.localScale = new Vector3(dballSize, dballSize, dballSize);
                    radiusMarker.transform.parent = transform;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null && !triedLookingForTarget)
        {
            target = GameObject.FindWithTag(targetTag);
            triedLookingForTarget = true;
        }

        if (display)
        {
            if (indicator != null)
            {
                if (targetDetected())
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

    public bool targetDetected()
    {
        if (target != null)
        {
            center = transform.position;

            Vector2 target_pos = target.GetComponent<Transform>().position;

            if (Vector2.Distance(center, target_pos) <= radius)
            {
                return true;
            }
        }
        return false;
    }
}
