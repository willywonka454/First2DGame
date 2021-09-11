using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDropper : MonoBehaviour
{

    public Transform dropLocation;

    public GameObject coinPrefab;

    public void dropCoin(int coinValue)
    {
        GameObject newCoin = Instantiate(coinPrefab, dropLocation.position, dropLocation.rotation);

        Coin coinScript = newCoin.GetComponent<Coin>();

        coinScript.value = coinValue;
    }
}
