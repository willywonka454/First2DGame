using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalSaveProtocol : MonoBehaviour
{

    public GeneralSaver mySaveProtocol;

    public GeneralSaver returnMySaveProtocol()
    {
        return mySaveProtocol;
    }
}
