using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class Brick : MonoBehaviour
    {

        public static int BreakableCount = 0;
        public GameObject Smoke;

        [SerializeField]
        private Sprite[] _hitSprites;
        private int _timesHit;

        [SerializeField]
        private int _pointsForBreaking = 5;

        private SpriteRenderer _spriteRenderer;
        private bool _isBreakable ;

        /// <summary>
        /// Use this for initialization
        /// </summary>
        void Start()
        {
            _isBreakable = (this.tag == "Breakable");
            _timesHit = 0;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            
            if (_isBreakable)
            {
                HandleHits();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleHits() {
            _timesHit++;
            int maxHits = _hitSprites.Length + 1;
            if (_timesHit >= maxHits)
            {
                //add score value
                GameManager.Instance.AddToScore(_pointsForBreaking);

                //kill block
                KillBlock();

            }
            else
            {
                LoadSprites();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadSprites() {
            int index = _timesHit - 1;
            _spriteRenderer.sprite = _hitSprites[index];
        }

        /// <summary>
        /// 
        /// </summary>
        private void KillBlock()
        {

            SpawnParticles();
            //hide and disable block collisions
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            //Debug.Log("Count before subtraction" + breakableCount);
            BreakableCount--;
            //Debug.Log(breakableCount);
            
            GameManager.Instance.BrickDestroyed();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SpawnParticles()
        {
            //Instantiate(smoke, transform.position, Quaternion.identity);
            GameManager.Instance.ParticleControl.SpawnSmokeParticles(transform.position);
        }

    }
}
