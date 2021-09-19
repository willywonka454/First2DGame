using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    public GameObject coinPrefab;

    // Start is called before the first frame update
    void Start()
    {
        MyScene myScene = SceneData.load();

        if (myScene != null)
        {
            GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

            for (int i = 0; i < coins.Length; i++)
            {
                Destroy(coins[i]);
            }

            for (int i = 0; i < myScene.myCoins.Count; i++)
            {
                GameObject newCoin = Instantiate(coinPrefab, myScene.myCoins[i].pos, myScene.myCoins[i].quat);

                Coin coinScript = newCoin.GetComponent<Coin>();
                coinScript.value = myScene.myCoins[i].val;
            }
        }
    }
}
