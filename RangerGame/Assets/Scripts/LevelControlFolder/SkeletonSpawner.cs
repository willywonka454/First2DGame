using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawner : MonoBehaviour
{

    public GameObject skeletonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        MyScene myScene = SceneData.load();

        if (myScene != null)
        {
            GameObject[] skeletons = GameObject.FindGameObjectsWithTag("Skeleton");

            for (int i = 0; i < skeletons.Length; i++)
            {
                Destroy(skeletons[i].transform.parent.gameObject);
            }

            for (int i = 0; i < myScene.mySkeletons.Count; i++)
            {                
                GameObject skeleton = Instantiate(skeletonPrefab, myScene.mySkeletons[i].pos, myScene.mySkeletons[i].quat);

                Transform childTrans = skeleton.transform.Find("Skeleton");
                childTrans.localScale = myScene.mySkeletons[i].scale;

                GameObject childObj = childTrans.gameObject;

                SkeletonMovement skelMov = childObj.GetComponent<SkeletonMovement>();
                skelMov.dirX = myScene.mySkeletons[i].dirX;

                Health healthScript = childObj.GetComponent<Health>();
                healthScript.hp = myScene.mySkeletons[i].health;
            }
        }
    }
}
