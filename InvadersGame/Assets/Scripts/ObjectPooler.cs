using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Object Pooler Class 
*/

public class ObjectPooler<T> : MonoBehaviour {

    [SerializeField]
    private T _object;
    private int poolSize;

    private void Start()
    {
        //instantiate object pool
    }

    public T SpawnObject()
    {

        return _object;
    }

    public void DespawnObject(T objectToDespawn)
    {
        
    }

}
