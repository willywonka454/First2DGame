using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    public static MyScene[] scenes = new MyScene[LevelControl.getNumScenes()];

    public static int sceneIndex;

    public static void save()
    {
        string sceneName = LevelControl.getSceneName();
        sceneIndex = LevelControl.getCurrScene();        
        scenes[sceneIndex] = new MyScene(sceneName, sceneIndex);

        saveCoins();        
        saveBats();
        saveSkeletons();
        saveWolves();
    }

    public static MyScene load()
    {
        sceneIndex = LevelControl.getCurrScene();

        return scenes[sceneIndex];
    }

    public static void reset()
    {
        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i] = null;
        }
    }

    public static void saveCoins()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        for (int i = 0; i < coins.Length; i++)
        {
            Transform coinTrans = coins[i].GetComponent<Transform>();
            Vector3 coinPos = new Vector3(coinTrans.position.x, coinTrans.position.y, coinTrans.position.z);
            Quaternion coinQuat = new Quaternion(coinTrans.rotation.x, coinTrans.rotation.y, coinTrans.rotation.z, coinTrans.rotation.w);

            Coin coinScript = coins[i].GetComponent<Coin>();
            int coinVal = coinScript.value;

            scenes[sceneIndex].myCoins.Add(new MyCoin(coinPos, coinQuat, coinVal));
        }
    }

    public static void saveSkeletons()
    {
        GameObject[] skeletons = GameObject.FindGameObjectsWithTag("Skeleton");

        for (int i = 0; i < skeletons.Length; i++)
        {
            Transform skeletonTrans = skeletons[i].GetComponent<Transform>();
            Vector3 skeletonPos = new Vector3(skeletonTrans.position.x, skeletonTrans.position.y, skeletonTrans.position.z);
            Quaternion skeletonQuat = new Quaternion(skeletonTrans.rotation.x, skeletonTrans.rotation.y, skeletonTrans.rotation.z, skeletonTrans.rotation.w);
            Vector3 skeletonScale = new Vector3(skeletonTrans.localScale.x, skeletonTrans.localScale.y, skeletonTrans.localScale.z);

            SkeletonMovement skelMov = skeletons[i].GetComponent<SkeletonMovement>();
            Health healthScript = skeletons[i].GetComponent<Health>();
            int skelHP = healthScript.hp;

            int skeletondirX = skelMov.dirX;

            scenes[sceneIndex].mySkeletons.Add(new MySkeleton(skeletonPos, skeletonQuat, skeletonScale, skeletondirX, skelHP));
        }
    }

    public static void saveWolves()
    {
        GameObject[] wolves = GameObject.FindGameObjectsWithTag("Wolf");

        for (int i = 0; i < wolves.Length; i++)
        {
            Transform wolfTrans = wolves[i].GetComponent<Transform>();
            Vector3 wolfPos = new Vector3(wolfTrans.position.x, wolfTrans.position.y, wolfTrans.position.z);
            Quaternion wolfQuat = new Quaternion(wolfTrans.rotation.x, wolfTrans.rotation.y, wolfTrans.rotation.z, wolfTrans.rotation.w);
            Vector3 wolfScale = new Vector3(wolfTrans.localScale.x, wolfTrans.localScale.y, wolfTrans.localScale.z);

            SkeletonMovement wolfMov = wolves[i].GetComponent<SkeletonMovement>();
            Health healthScript = wolves[i].GetComponent<Health>();
            int wolfHP = healthScript.hp;

            int wolfdirX = wolfMov.dirX;

            scenes[sceneIndex].myWolves.Add(new MyWolf(wolfPos, wolfQuat, wolfScale, wolfdirX, wolfHP));
        }
    }

    public static void saveBats()
    {
        GameObject[] bats = GameObject.FindGameObjectsWithTag("Bat");

        for (int i = 0; i < bats.Length; i++)
        {
            Transform batTrans = bats[i].GetComponent<Transform>();
            Vector3 batPos = new Vector3(batTrans.position.x, batTrans.position.y, batTrans.position.z);
            Quaternion batQuat = new Quaternion(batTrans.rotation.x, batTrans.rotation.y, batTrans.rotation.z, batTrans.rotation.w);
            Vector3 batScale = new Vector3(batTrans.localScale.x, batTrans.localScale.y, batTrans.localScale.z);

            BatMovement batMov = bats[i].GetComponent<BatMovement>();
            Health healthScript = bats[i].GetComponent<Health>();
            int batHP = healthScript.hp;

            int batdirY = batMov.dirY;

            scenes[sceneIndex].myBats.Add(new MyBat(batPos, batQuat, batScale, batdirY, batHP));
        }
    }
}

public class MyScene
{
    public string name;
    public int index;

    public List<MyCoin> myCoins = new List<MyCoin>();
    public List<MyBat> myBats = new List<MyBat>();
    public List<MySkeleton> mySkeletons = new List<MySkeleton>();
    public List<MyWolf> myWolves = new List<MyWolf>();

    public MyScene(string sceneName, int sceneIndex)
    {
        name = sceneName;
        index = sceneIndex;
    }
}

public class MyCoin
{
    public Vector3 pos;
    public Quaternion quat;
    public int val;

    public MyCoin(Vector3 newPos, Quaternion newQuat, int newVal)
    {
        pos = newPos;
        quat = newQuat;
        val = newVal;
    }
}

public class MySkeleton
{
    public Vector3 pos;
    public Quaternion quat;
    public Vector3 scale;
    public int dirX;
    public int health;

    public MySkeleton(Vector3 newPos, Quaternion newQuat, Vector3 newScale, int newDirX, int newHealth)
    {
        pos = newPos;
        quat = newQuat;
        scale = newScale;
        dirX = newDirX;
        health = newHealth;
    }
}

public class MyBat
{
    public Vector3 pos;   
    public Quaternion quat;
    public Vector3 scale;
    public int dirY;
    public int health;
    
    public MyBat(Vector3 newPos, Quaternion newQuat, Vector3 newScale, int newDirY, int newHealth)
    {
        pos = newPos;
        quat = newQuat;
        scale = newScale;
        dirY = newDirY;
        health = newHealth;
    }
}

public class MyWolf
{
    public Vector3 pos;
    public Quaternion quat;
    public Vector3 scale;
    public int dirX;
    public int health;

    public MyWolf(Vector3 newPos, Quaternion newQuat, Vector3 newScale, int newDirX, int newHealth)
    {
        pos = newPos;
        quat = newQuat;
        scale = newScale;
        dirX = newDirX;
        health = newHealth;
    }
}
