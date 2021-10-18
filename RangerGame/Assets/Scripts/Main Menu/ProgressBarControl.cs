using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ProgressBarControl : MonoBehaviour
{

    public Image fillImage;
    public Image bgImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFillPercent(float percent)
    {
        fillImage.fillAmount = percent;
    }

    public void setFillColor(Color newColor)
    {
        fillImage.color = newColor;
    }

    public void setBGColor(Color newColor)
    {
        bgImage.color = newColor;
    }
}
