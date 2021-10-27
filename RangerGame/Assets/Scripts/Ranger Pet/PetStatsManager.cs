using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class PetStatsManager : MonoBehaviour
{
    [Header("Pet Scripts")]
    public PetCombat petCombat;
    public PlayerXP petXP;

    [Header("Text boxes")]
    public TMP_Text levelText;
    public TMP_Text attackText;
    public TMP_Text xpNeededText;

    // Start is called before the first frame update
    void Start()
    {
        petXP = GameObject.FindWithTag("Pet").GetComponent<PlayerXP>();
        petCombat = GameObject.FindWithTag("Pet").GetComponent<PetCombat>();

        Transform target;
        if (target = transform.Find("Level value")) levelText = target.GetComponent<TMP_Text>();
        if (target = transform.Find("Xp needed")) xpNeededText = target.GetComponent<TMP_Text>();
        if (target = transform.Find("Attack value")) attackText = target.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelText != null) levelText.text = "" + petXP.currLevel;

        if (xpNeededText != null) xpNeededText.text = (petXP.currXP - petXP.currMinXP) + "/" + (petXP.currMaxXP - petXP.currMinXP);

        if (attackText != null) attackText.text = "" + petCombat.attack;
    }
}
