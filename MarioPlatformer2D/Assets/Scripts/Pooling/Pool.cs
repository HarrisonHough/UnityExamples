using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Pool Class
*/

public class Pool : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabToPool;
    [SerializeField]
    private int poolSize = 50;

    private readonly Queue<GameObject> objectQueue = new Queue<GameObject>();
    private readonly List<GameObject> objectPool = new List<GameObject>();

    private void Awake()
    {
        GrowPool();
    }
    
    public GameObject GetObject()
    {
        if (objectQueue.Count == 0)
        {
            GrowPool();
        }

        GameObject pooledObject = objectQueue.Dequeue();

        return pooledObject;
    }
    
    private void GrowPool()
    {
        var lastPoolSize = objectPool.Count;
        for (var i = 0; i < poolSize; i++)
        {
            GameObject pooledObject = Instantiate(prefabToPool);
            pooledObject.name += " " + (i + lastPoolSize);
            pooledObject.transform.parent = transform;
            pooledObject.AddComponent<PoolMember>();

            //TODO maybe set on disable event
            pooledObject.GetComponent<PoolMember>().OnDestroyEvent += () => AddObjectToAvailable(pooledObject);
            
            objectPool.Add(pooledObject);

            pooledObject.SetActive(false);
        }
    }
    
    private void AddObjectToAvailable(GameObject pooledObject)
    {
        objectQueue.Enqueue(pooledObject);
    }

    public void DisableAfterDelay(GameObject objectToDisable, float delay)
    {

    }
}
