using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public Text myText;

    public PlayerHP healthScript;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript != null) myText.text = "" + healthScript.hp;
        else myText.text = "" + GlobalVars.playerHP;
    }
}
