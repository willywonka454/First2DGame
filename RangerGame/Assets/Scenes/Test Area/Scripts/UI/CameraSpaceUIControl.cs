using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpaceUIControl : MonoBehaviour
{
    public GameObject respawnMenu;

    // Start is called before the first frame update
    void Start()
    {
        if (GDMContainer.myGDM.gameData.respawnMenuIsActive) respawnMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
