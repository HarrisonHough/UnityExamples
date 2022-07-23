using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour {

    [SerializeField]
    private GameObject _smokePrefab;
    private ParticleSystem[] _smokePool;
    [SerializeField]
    private int _poolSize = 5;
    private int _poolIndex = 0;
	// Use this for initialization
	void Start () {
        CreateSmokeParticlePool();
	}

    void CreateSmokeParticlePool()
    {
        _smokePool = new ParticleSystem[_poolSize];
        for (int i = 0; i < _smokePool.Length; i++)
        {
            //create smoke particle object
            GameObject smokeObject = Instantiate(_smokePrefab,Vector3.zero, Quaternion.identity);
            //parent under this object
            smokeObject.transform.parent = transform;
            //assign in array
            _smokePool[i] = smokeObject.GetComponent<ParticleSystem>();
        }
    }

    public void SpawnSmokeParticles(Vector3 position)
    {
        _smokePool[_poolIndex].transform.position = position;
        _smokePool[_poolIndex].Play();

        _poolIndex++;
        if (_poolIndex >= _smokePool.Length)
        {
            _poolIndex = 0;
        }
    }
}
