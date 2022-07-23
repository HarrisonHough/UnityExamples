using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Pool Class
*/

/// <summary>
/// 
/// </summary>
public class Pool : MonoBehaviour
{

    [FormerlySerializedAs("_prefabToPool"), SerializeField]
    private GameObject prefabToPool;
    [FormerlySerializedAs("_poolSize"), SerializeField]
    private int poolSize = 50;

    private readonly Queue<GameObject> objectsQueue = new Queue<GameObject>();
    private readonly List<GameObject> objectPool = new List<GameObject>();

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Awake()
    {
        GrowPool();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public GameObject GetObject()
    {
        if (objectsQueue.Count == 0)
        {
            GrowPool();
        }

        GameObject pooledObject = objectsQueue.Dequeue();

        return pooledObject;
    }

    /// <summary>
    /// 
    /// </summary>
    private void GrowPool()
    {
        var lastPoolSize = objectPool.Count;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject pooledObject = Instantiate(prefabToPool);
            pooledObject.name += " " + (i + lastPoolSize);
            pooledObject.transform.parent = transform;
            pooledObject.AddComponent<PoolMember>();

            //TODO maybe set on disable event
            pooledObject.GetComponent<PoolMember>().OnDestroyEvent += () => AddObjectToAvailable(pooledObject);

            //add to pool
            objectPool.Add(pooledObject);

            pooledObject.SetActive(false);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pooledObject"></param>
    private void AddObjectToAvailable(GameObject pooledObject)
    {
        objectsQueue.Enqueue(pooledObject);
    }

    public void DisableAfterDelay(GameObject objectToDisable, float delay)
    {

    }
}
