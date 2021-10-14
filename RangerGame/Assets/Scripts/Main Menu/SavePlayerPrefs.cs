using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPrefs : MonoBehaviour
{

    public static SavePlayerPrefs original;

    void Awake()
    {        
        if (original == null)
        {
            original = this;
            DontDestroyOnLoad(gameObject);
        }

        else if (this != original)
        {
            Destroy(gameObject);
        }
    }

    void OnApplicationQuit()
    {
        Debug.Log(Screen.width);
    }
}
