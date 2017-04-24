using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

    [SerializeField]
    private GameObject wallPooled;

    public int pooledAmount;

    List<GameObject> pooledWalls;

	void Start () {
        pooledWalls = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(wallPooled);
            obj.SetActive(false);
            pooledWalls.Add(obj);
        }
	}

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledWalls.Count; i++)
        {
            if (!pooledWalls[i].activeInHierarchy)
            {
                return pooledWalls[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(wallPooled);
        obj.SetActive(false);
        pooledWalls.Add(obj);
        return obj;
    }
}
