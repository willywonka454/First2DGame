using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class LevelTest : MonoBehaviour
{
    [Header("Text")]
    public TMP_Text levelVal;
    public TMP_Text xpVal;
    public TMP_Text relativeXPVal;
    public TMP_Text percentVal;

    [Header("Buttons")]
    public Button setLevelBtn;
    public Button setXPBtn;
    public Button addXPBtn;
    public Button setMultiplierBtn;
    public Button setInitialXPBtn;
    public Button resetBtn;

    [Header("Input fields")]
    public TMP_InputField setLevelInput;
    public TMP_InputField setXPInput;
    public TMP_InputField addXPInput;
    public TMP_InputField multiplierInput;
    public TMP_InputField initialXPInput;
    public TMP_InputField resetInput;

    [Header("Player")]
    public GameObject player;
    public PlayerXP playerXPScript;

    // Start is called before the first frame update
    void Start()
    {
        playerXPScript = player.GetComponent<PlayerXP>();
    }

    // Update is called once per frame
    void Update()
    {
        levelVal.text = "" + playerXPScript.currLevel;

        xpVal.text = playerXPScript.currXP + "/" + playerXPScript.currMaxXP;

        percentVal.text = "" + (int) (playerXPScript.percentTowardsNextLevel() * 100) + "%";

        relativeXPVal.text = (playerXPScript.currXP - playerXPScript.currMinXP) + "/" + (playerXPScript.currMaxXP - playerXPScript.currMinXP);
    }

    public void reset()
    {
        string resetLevel = "level";
        string totalReset = "total";

        string userInput = resetInput.text;

        if (userInput.Equals(resetLevel))
        {
            playerXPScript.currXP = playerXPScript.currMinXP;
        }

        if (userInput.Equals(totalReset))
        {
            playerXPScript.reset();
        }
    }

    public void setLevel()
    {
        int newLevel = int.Parse(setLevelInput.text);

        playerXPScript.setLevel(newLevel);
    }

    public void setXP()
    {
        int newXP = int.Parse(setXPInput.text);

        playerXPScript.setXP(newXP);
    }

    public void addXP()
    {
        int xpToAdd = int.Parse(addXPInput.text);

        int currXP = playerXPScript.currXP;

        playerXPScript.setXP(currXP + xpToAdd);
    }

    public void setInitialXPRequired()
    {
        int newInitial = int.Parse(initialXPInput.text);

        playerXPScript.setInitialXPNeeded(newInitial);
    }

    public void setMultiplier()
    {
        float newMultiplier = float.Parse(multiplierInput.text);

        playerXPScript.setMultiplier(newMultiplier);
    }
}
