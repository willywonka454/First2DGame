using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSaver : MonoBehaviour
{
    public virtual void Awake()
    {

    }

    public virtual void Start()
    {
        
    }

    public virtual void saveMyDataToSceneObject(SceneObject sceneObject)
    {
        sceneObject.myPos = transform.position;        
        sceneObject.myRotation = transform.rotation;
        sceneObject.myLocalScale = transform.localScale;
        sceneObject.myName = gameObject.tag;
    }

    public virtual void loadDataFromSceneObjectToMyGameObject(SceneObject sceneObject)
    {
        transform.position = sceneObject.myPos;
        transform.rotation = sceneObject.myRotation;
        transform.localScale = sceneObject.myLocalScale;
    }

    public virtual void assignPlayerToEntryPoint()
    {
        Vector3 newPos = findMyEntryPointPos();
        transform.position = newPos;
        transform.localScale = GDMContainer.myGDM.gameData.entryPointData.playerLocalScaleOnArrival;
        GDMContainer.myGDM.gameData.entryPointData.isEmpty = true;
    }

    public virtual void assignGenericObjectToEntryPoint()
    {
        Vector3 newPos = findMyEntryPointPos();
        transform.position = newPos;
    }

    public virtual Vector3 findMyEntryPointPos()
    {
        string myEntryPointName = GDMContainer.myGDM.gameData.entryPointData.myName;
        Object[] entryPoints = Object.FindObjectsOfType<EntryPoint>();
        foreach (EntryPoint entryPoint in entryPoints)
        {
            if (entryPoint.myName == myEntryPointName)
            {
                return entryPoint.transform.position;
            }
        }

        return new Vector3(0, 0, 0);
    }

    public virtual bool entryPointExists()
    {
        GameData gameData = GDMContainer.myGDM.gameData;

        if (gameData.entryPointData.isEmpty) return false;
        else return true;
    }
}
