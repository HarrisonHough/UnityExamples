using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrickBreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class DestroyAfterParticles : MonoBehaviour
    {

        private ParticleSystem _particles;

        /// <summary>
        /// Use this for initialization
        /// </summary>
        void Start()
        {
            _particles = GetComponent<ParticleSystem>();

            Invoke("DestroySelf", _particles.main.duration + 1f);
        }

        /// <summary>
        /// 
        /// </summary>
        void DestroySelf()
        {
            Debug.Log("Destroying game object");
            Destroy(gameObject);
        }
    }
}
