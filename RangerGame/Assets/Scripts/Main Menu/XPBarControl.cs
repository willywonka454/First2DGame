using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class XPBarControl : MonoBehaviour
{
    [Header("Progress Bar and PlayerXP")]
    public ProgressBarControl progressBar;
    public PlayerXP playerXP;

    [Header("Text Boxes")]
    public TMP_Text levelText;
    public TMP_Text xpNeededText;
    public TMP_Text totalXPText;
    public TMP_Text percentText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < players.Length; i++)
        {
            playerXP = players[i].GetComponent<PlayerXP>();
            if (playerXP != null) break;
        }

        progressBar = GetComponentInChildren<ProgressBarControl>();

        Transform target;
        if (target = transform.Find("Level")) levelText = target.GetComponent<TMP_Text>();
        if (target = transform.Find("Xp needed")) xpNeededText = target.GetComponent<TMP_Text>();
        if (target = transform.Find("Total xp")) totalXPText = target.GetComponent<TMP_Text>();
        if (target = transform.Find("Percent")) percentText = target.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.setFillPercent(playerXP.percentTowardsNextLevel());

        if (levelText != null) levelText.text = "Lvl. " + playerXP.currLevel;

        if (xpNeededText != null) xpNeededText.text = (playerXP.currXP - playerXP.currMinXP) + "/" + (playerXP.currMaxXP - playerXP.currMinXP);

        if (totalXPText != null) totalXPText.text = playerXP.currXP + "/" + playerXP.currMaxXP;

        if (percentText != null) percentText.text = (int) (playerXP.percentTowardsNextLevel() * 100) + "%";
    }
}
