using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{

    public GameObject batPrefab;

    // Start is called before the first frame update
    void Start()
    {
        MyScene myScene = SceneData.load();

        if (myScene != null)
        {
            GameObject[] bats = GameObject.FindGameObjectsWithTag("Bat");

            for (int i = 0; i < bats.Length; i++)
            {
                Destroy(bats[i].transform.parent.gameObject);
            }

            for (int i = 0; i < myScene.myBats.Count; i++)
            {
                GameObject bat = Instantiate(batPrefab, myScene.myBats[i].pos, myScene.myBats[i].quat);

                Transform childTrans = bat.transform.Find("Bat");
                childTrans.localScale = myScene.myBats[i].scale;

                GameObject childObj = childTrans.gameObject;

                BatMovement batMov = childObj.GetComponent<BatMovement>();
                batMov.dirY = myScene.myBats[i].dirY;

                Health healthScript = childObj.GetComponent<Health>();
                healthScript.hp = myScene.myBats[i].health;
            }
        }
    }
}
