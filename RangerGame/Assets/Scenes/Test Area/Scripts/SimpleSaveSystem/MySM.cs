using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public static class MySM
{
    public static void loadScene(int index = 0, string name = null)
    {
        if (name == null)
        {
            SceneManager.LoadScene(index);
        }

        else
        {
            SceneManager.LoadScene(name);
        }

        //GDMContainer.myGDM.saveCurrentScene();
    }
}
