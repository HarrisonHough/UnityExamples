using UnityEngine;

namespace BrickBreaker
{
    public class DestroyAfterParticles : MonoBehaviour
    {

        private ParticleSystem particles;
        
        void Start()
        {
            particles = GetComponent<ParticleSystem>();

            Invoke(nameof(DestroySelf), particles.main.duration + 1f);
        }
        
        void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}
