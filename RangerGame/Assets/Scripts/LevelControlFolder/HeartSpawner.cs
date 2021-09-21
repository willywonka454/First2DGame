using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{

    public GameObject heartPrefab;

    public GameObject[] heartsToSpawn;

    public bool spawnHearts;

    GameObject[] skeletons;
    GameObject[] bats;
    GameObject[] wolves;

    bool enemiesInScene;

    // Start is called before the first frame update
    void Start()
    {       
        for (int i = 0; i < heartsToSpawn.Length; i++)
        {
            heartsToSpawn[i].SetActive(false);
        }

        MyScene myScene = SceneData.load();

        if (myScene != null)
        {
            enemiesInScene = (myScene.mySkeletons.Count > 0 || myScene.myBats.Count > 0 || myScene.myWolves.Count > 0);
        }

        else
        {
            skeletons = GameObject.FindGameObjectsWithTag("Skeleton");
            bats = GameObject.FindGameObjectsWithTag("Bat");
            wolves = GameObject.FindGameObjectsWithTag("Wolf");

            enemiesInScene = (skeletons.Length > 0 || bats.Length > 0 || wolves.Length > 0);
        }

        if (enemiesInScene)
        {
            spawnHearts = true;
        }

        else
        {
            spawnHearts = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        skeletons = GameObject.FindGameObjectsWithTag("Skeleton");
        bats = GameObject.FindGameObjectsWithTag("Bat");
        wolves = GameObject.FindGameObjectsWithTag("Wolf");

        bool noEnemies = (skeletons.Length <= 0 && bats.Length <= 0 && wolves.Length <= 0);

        if (noEnemies && spawnHearts == true)
        {
            for (int i = 0; i < heartsToSpawn.Length; i++)
            {
                heartsToSpawn[i].SetActive(true);
            }

            spawnHearts = false;
        }
    }
}
