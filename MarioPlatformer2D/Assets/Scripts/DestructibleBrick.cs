using UnityEngine;

public class DestructibleBrick : MonoBehaviour, IDestructible
{
    public void Destroy()
    {
        var particles = GameManager.Instance.destroyParticlesPool.GetObject().GetComponent<ParticleEffect>();

        particles.PlayAtPosition(transform.position);
        gameObject.SetActive(false);
    }
}
