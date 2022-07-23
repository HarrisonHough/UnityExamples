using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    [SerializeField]
    private GameObject smokePrefab;
    private ParticleSystem[] smokePool;
    [SerializeField]
    private int poolSize = 5;
    private int poolIndex;

    private void Start()
    {
        CreateSmokeParticlePool();
    }

    void CreateSmokeParticlePool()
    {
        smokePool = new ParticleSystem[poolSize];
        for (var i = 0; i < smokePool.Length; i++)
        {
            GameObject smokeObject = Instantiate(smokePrefab, Vector3.zero, Quaternion.identity);
            smokeObject.transform.parent = transform;
            smokePool[i] = smokeObject.GetComponent<ParticleSystem>();
        }
    }

    public void SpawnSmokeParticles(Vector3 position)
    {
        smokePool[poolIndex].transform.position = position;
        smokePool[poolIndex].Play();

        poolIndex++;
        if (poolIndex >= smokePool.Length)
        {
            poolIndex = 0;
        }
    }
}
