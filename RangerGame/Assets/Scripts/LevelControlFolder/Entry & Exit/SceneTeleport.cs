using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTeleport : MonoBehaviour
{
    // A SceneTeleport will have a target destination (a scene).
    public int targetSceneIndex = 0;
    public string targetSceneName = "";

    // A SceneTeleport will have a desired entry point in the target destination. 
    public int entryPointID = 0;
    public string entryPointName = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // A SceneTeleport should be able to teleport the player to the target destination.
    public void teleport()
    {
        if (string.IsNullOrEmpty(targetSceneName))
        {

        }

        else
        {

        }

        // Save the current scene index and name, and desired entry point to GlobalVars.
        // Or should this be handled by the script that handles saving and loading levels?
        // Well, this script is the only thing that has access to the desired entry point.
    }
}
