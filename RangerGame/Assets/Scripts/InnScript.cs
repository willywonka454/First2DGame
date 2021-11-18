using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InnScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject myText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myText.SetActive(false);
    }
}
