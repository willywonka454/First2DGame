using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSpawner : MonoBehaviour
{

    public GameObject wolfPrefab;

    // Start is called before the first frame update
    void Start()
    {
        MyScene myScene = SceneData.load();

        if (myScene != null)
        {
            GameObject[] wolves = GameObject.FindGameObjectsWithTag("Wolf");

            for (int i = 0; i < wolves.Length; i++)
            {
                Destroy(wolves[i].transform.parent.gameObject);
            }

            for (int i = 0; i < myScene.myWolves.Count; i++)
            {
                GameObject wolf = Instantiate(wolfPrefab, myScene.myWolves[i].pos, myScene.myWolves[i].quat);

                Transform childTrans = wolf.transform.Find("Wolf");
                childTrans.localScale = myScene.myWolves[i].scale;

                GameObject childObj = childTrans.gameObject;

                SkeletonMovement wolfMov = childObj.GetComponent<SkeletonMovement>();
                wolfMov.dirX = myScene.myWolves[i].dirX;

                Health healthScript = childObj.GetComponent<Health>();
                healthScript.hp = myScene.myWolves[i].health;
            }
        }
    }
}
