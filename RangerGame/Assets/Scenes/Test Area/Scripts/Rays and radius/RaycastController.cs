using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class RaycastController : MonoBehaviour
{
    public DetectRaycast detectRaycast;

    public Button shootRayButton;
    public TMP_Text hitStatusText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shootRayButtonClicked()
    {
        bool hit = detectRaycast.shootRay();

        if (hit) hitStatusText.text = "Status: successful hit";
        else hitStatusText.text = "Status: unsuccessful hit";       
    }
}
