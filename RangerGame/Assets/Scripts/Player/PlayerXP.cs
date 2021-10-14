using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int initialXPNeededToLevelUp = 83;

    public int currXP = 0;
    public int currMinXP = 0;
    public int currMaxXP = 83;

    public int currLevel = 1;

    public float multiplier = 1.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reset()
    {
        currLevel = 1;
        currXP = 0;
        currMinXP = 0;
        currMaxXP = initialXPNeededToLevelUp;
    }

    public void setMultiplier(float newMultiplier)
    {
        multiplier = newMultiplier;
        reset();
    }

    public void setInitialXPNeeded(int newInitial)
    {
        initialXPNeededToLevelUp = newInitial;
        reset();
    }

    public void setLevel(int newLevel)
    {
        float percentGathered = percentTowardsNextLevel();

        Dictionary<string, int> info = getInfoOnLevel(newLevel);

        currLevel = info["Level"];
        currMinXP = info["MinXP"];
        currMaxXP = info["MaxXP"];

        int xpNeeded = currMaxXP - currMinXP;
        int xpGatheredTowardsNextLevel = (int)(percentGathered * xpNeeded);

        currXP = currMinXP + xpGatheredTowardsNextLevel;
    }

    public void setXP(int newxp)
    {
        if (newxp >= currMaxXP || newxp < currMinXP)
        {
            Dictionary<string, int> info = getInfoOnXP(newxp);

            currLevel = info["Level"];
            currMinXP = info["MinXP"];
            currMaxXP = info["MaxXP"];
        }

        currXP = newxp;
    }
    
    public Dictionary<string, int> getInfoOnXP(int xp)
    {
        Dictionary<string, int> info = new Dictionary<string, int>();

        int localLevel = 1;
        int localCurrMinXP = 0;
        int localCurrMaxXP = initialXPNeededToLevelUp;
        int xpNeeded = initialXPNeededToLevelUp;

        while(xp >= localCurrMaxXP)
        {
            xpNeeded = (int)((localCurrMaxXP - localCurrMinXP) * multiplier);

            localCurrMinXP = localCurrMaxXP;

            localCurrMaxXP += xpNeeded;

            localLevel += 1;
        }

        info.Add("Level", localLevel);
        info.Add("MinXP", localCurrMinXP);
        info.Add("MaxXP", localCurrMaxXP);

        return info;
    }

    public Dictionary<string, int> getInfoOnLevel(int level)
    {
        Dictionary<string, int> info = new Dictionary<string, int>();

        int localLevel = 1;
        int localCurrMinXP = 0;
        int localCurrMaxXP = initialXPNeededToLevelUp;
        int xpNeeded = initialXPNeededToLevelUp;

        while(localLevel < level)
        {
            xpNeeded = (int) ((localCurrMaxXP - localCurrMinXP) * multiplier);

            localCurrMinXP = localCurrMaxXP;

            localCurrMaxXP += xpNeeded;

            localLevel += 1;
        }

        info.Add("Level", localLevel);
        info.Add("MinXP", localCurrMinXP);
        info.Add("MaxXP", localCurrMaxXP);

        return info;
    }

    public float percentTowardsNextLevel()
    {
        int xpNeeded = currMaxXP - currMinXP;
        int xpGatheredTowardsNextLevel = currXP - currMinXP;

        float percentGathered = ((xpGatheredTowardsNextLevel * 1.0f) / xpNeeded);

        return percentGathered;
    }
}
