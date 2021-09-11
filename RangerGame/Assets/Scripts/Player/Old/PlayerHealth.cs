using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void AfterDeathLogic()
    {
        LevelControl.RestartLevel();
    }

    void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            takeDmg(20);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "LifeHeart")
        {
            int hpBefore = hp;
            heal(20);
            if (hpBefore != hp) Destroy(collider.gameObject);
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

        if (hp <= 0) Die();
    }

    int returnNumOfHearts(int hp)
    {
        int heartCounter = 0;

        foreach(var bound in heartBounds)
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

public class Bound
{
    public int lowerBound = 0;
    public int upperBound = 0;
    
    public Bound(int newLowerBound, int newUpperBound)
    {
        this.lowerBound = newLowerBound;
        this.upperBound = newUpperBound;
    }

    public Bound() { }
}
