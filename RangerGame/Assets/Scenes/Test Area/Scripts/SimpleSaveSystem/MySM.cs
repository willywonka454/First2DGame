using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public static class MySM
{
    public static void loadScene(string name)
    {
        GDMContainer.myGDM.saveCurrentScene();

        SceneManager.LoadScene(name);       
    }

    public static void loadScene(int index)
    {
        GDMContainer.myGDM.saveCurrentScene();

        SceneManager.LoadScene(index);
    }
}
