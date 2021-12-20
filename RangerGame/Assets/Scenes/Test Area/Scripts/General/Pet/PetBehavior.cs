using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBehavior : MonoBehaviour
{
    public MoveTowardsTarget moveTowardsTarget;
    public int defaultStopDistance = 5;
    public int coinStopDistance = 1;

    public GameObject player;
    public GameObject enemy;
    public GameObject coin;

    public enum Mode
    {
        AtRest, 
        FollowingPlayer,
        FollowingCoin,
        FollowingEnemy
    }

    public Mode myMode;

    public string[] enemyTags = { "Wolf", "Skeleton", "Dragon" };

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        moveTowardsTarget = GetComponent<MoveTowardsTarget>();

        StartCoroutine("searchingForEnemy");
        StartCoroutine("searchingForCoin");
        StartCoroutine("executeAttacksOnEnemy");  
        
        if (player != null && GDMContainer.myGDM.gameData.hasBoughtPet)
        {
            transform.position = player.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        determineMyMode();

        determineBehaviorGivenMode();

        moveTowardsTarget.followTarget();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coin") collidedWithCoin(col.gameObject);
    }

    public void determineMyMode()
    {
        if (player == null) myMode = Mode.AtRest;
        else
        {
            if (enemy == null)
            {
                if (coin == null) myMode = Mode.FollowingPlayer;
                else myMode = Mode.FollowingCoin;
            }
            else myMode = Mode.FollowingEnemy;
        }
    }

    public void determineBehaviorGivenMode()
    {
        switch (myMode)
        {
            case Mode.AtRest:
                break;
            case Mode.FollowingPlayer:
                moveTowardsTarget.target = player;
                moveTowardsTarget.stopDistance = defaultStopDistance;
                break;
            case Mode.FollowingEnemy:
                moveTowardsTarget.target = enemy;
                moveTowardsTarget.stopDistance = defaultStopDistance;
                break;
            case Mode.FollowingCoin:
                moveTowardsTarget.target = coin;
                moveTowardsTarget.stopDistance = coinStopDistance;
                break;
        }
    }

    public void attackEnemy()
    {
        if (enemy != null && (Vector2.Distance(transform.position, enemy.transform.position) <= defaultStopDistance))
        {
            if (enemy.gameObject.tag == "Wolf")
            {
                WolfCombat wolfCombat = enemy.GetComponent<WolfCombat>();
                wolfCombat.takeDamage(20);
            }

            else if (enemy.gameObject.tag == "Skeleton")
            {
                SkeletonCombat skeletonCombat = enemy.GetComponent<SkeletonCombat>();
                skeletonCombat.takeDmg(20);
            }

            else if (enemy.gameObject.tag == "Dragon")
            {
                DragonCombat dragCombat = enemy.GetComponentInChildren<DragonCombat>();
                enemy = dragCombat.gameObject;
                dragCombat.takeDmg(5);
            }
        }
    }

    public GameObject searchForEnemy()
    {
        for (int i = 0; i < enemyTags.Length; i++)
        {
            enemy = GameObject.FindWithTag(enemyTags[i]);
            if (enemy != null) break;
        }
        return enemy;
    }

    IEnumerator searchingForEnemy()
    {
        while (true)
        {
            if (myMode != Mode.FollowingEnemy && myMode != Mode.AtRest)
            {
                enemy = searchForEnemy();
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }

    IEnumerator executeAttacksOnEnemy()
    {
        while (true)
        {
            if (enemy != null)
            {
                attackEnemy();
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }

    public void collidedWithCoin(GameObject collidedCoin)
    {
        if (collidedCoin != null && player != null)
        {
            PlayerInventoryV2 playerInventory = player.GetComponent<PlayerInventoryV2>();
            playerInventory.addCoins(collidedCoin.GetComponent<Coin>().value);
            Destroy(collidedCoin.gameObject);
        }
    }

    public GameObject searchForCoin()
    {
        coin = GameObject.FindWithTag("Coin");
        return coin;        
    }

    IEnumerator searchingForCoin()
    {
        while (true)
        {
            if (myMode != Mode.FollowingCoin && myMode != Mode.AtRest)
            {
                coin = searchForCoin();
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }
}
