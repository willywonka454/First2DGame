using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public Text myText;

    public Health healthScript;

    public Transform target;

    public float xOffSet;

    public float yOffSet;

    // Start is called before the first frame update
    void Start()
    {
        xOffSet = transform.position.x - target.position.x;
        yOffSet = transform.position.y - target.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = "" + healthScript.hp;

        transform.position = new Vector3(target.position.x + xOffSet, target.position.y + yOffSet, transform.position.z);
    }
}
