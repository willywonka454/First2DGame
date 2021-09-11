using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHearts;
    public int numHearts;
    public int hpPerHeart;
    public List<Bound> heartBounds;

    public int maxhp;
    public int hp;

    private Animator anim;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        heartBounds = returnNewHeartBounds();
        maxhp = maxHearts * hpPerHeart;
        hp = maxhp;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }

    void RemoveFromScene()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Arrow")
        {
            takeDmg(20);
            if (hp <= 0) Die();
        }
    }

    void heal(int healAmount)
    {
        int newHp = (hp + healAmount);
        if (newHp >= maxhp) hp = maxhp;
        else hp = newHp;

        numHearts = returnNumOfHearts(hp);
    }

    void takeDmg(int dmg)
    {
        int newHp = (hp - dmg);
        if (newHp <= 0) hp = 0;
        else hp = newHp;

        numHearts = returnNumOfHearts(hp);
    }

    int returnNumOfHearts(int hp)
    {
        int heartCounter = 0;

        foreach (var bound in heartBounds)
        {
            if (hp >= bound.lowerBound && hp <= bound.upperBound) break;
            else heartCounter++;
        }

        return heartCounter;
    }

    List<Bound> returnNewHeartBounds()
    {
        List<Bound> newHeartBounds = new List<Bound>();
        newHeartBounds.Add(new Bound(0, 0));

        for (int currHeart = 1; currHeart <= maxHearts; currHeart++)
        {
            Bound newBound = new Bound();
            newBound.upperBound = (currHeart * hpPerHeart);
            newBound.lowerBound = (newBound.upperBound + 1) - hpPerHeart;
            newHeartBounds.Add(newBound);
        }
        return newHeartBounds;
    }
}
