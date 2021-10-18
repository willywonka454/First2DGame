using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPBarControl : MonoBehaviour
{
    public ProgressBarControl progressBar;
    public PlayerXP playerXP;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerXP = player.GetComponent<PlayerXP>();

        progressBar = GetComponentInChildren<ProgressBarControl>();
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.setFillPercent(playerXP.percentTowardsNextLevel());
    }
}
