using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
    public int ID;
    public int nextLevel = -1;
    public bool prevScene = false;

    // Start is called before the first frame update
    void Start()
    {
        if (nextLevel == -1)
        {
            nextLevel = LevelControl.getCurrScene() + 1;
        }

        if (prevScene)
        {
            nextLevel = LevelControl.getCurrScene() - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GlobalVars.playerDirX = Mathf.Sign(col.gameObject.transform.localScale.x);
            GlobalVars.IDOfPrevExitPoint = ID;
            SceneData.save();
            LevelControl.loadLevelByIndex(nextLevel);
        }
    }

    public void clicked ()
    {
        GameObject player = GameObject.FindWithTag("Player");

        GlobalVars.playerDirX = Mathf.Sign(player.gameObject.transform.localScale.x);
        GlobalVars.IDOfPrevExitPoint = ID;
        SceneData.save();
        LevelControl.loadLevelByIndex(nextLevel);
    }
}
