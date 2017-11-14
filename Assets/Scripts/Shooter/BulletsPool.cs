using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour {

    public static BulletsPool current;
    public GameObject pooledObject;
    public int pooledAmount;
    public bool willGrow = false;

    List<GameObject> pooledObjects;

    // Use this for initialization
    void Start()
    {
        current = this;
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject, new Vector3(0, 0, 0), Quaternion.identity);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

    }
    public GameObject GetPulledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }
}
