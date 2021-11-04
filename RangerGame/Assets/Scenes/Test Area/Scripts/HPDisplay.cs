using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class HPDisplay : MonoBehaviour
{
    public GameObject target;

    public TMP_Text myText;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        myText.transform.position = target.transform.position;
    }
}
