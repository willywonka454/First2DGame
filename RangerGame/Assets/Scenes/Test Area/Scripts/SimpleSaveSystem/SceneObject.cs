using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneObject
{
    // Fields common to all scene objects.
    public string myName;
    public Vector3 myPos;
    public Quaternion myRotation;
    public Vector3 myLocalScale;

    // Fields common to player objects.
    public int hp;
    public int coins;
    public int arrows;

    // Fields common to bats.
    public int dirY;

    // Fields common to coins;
    public int value;
}
