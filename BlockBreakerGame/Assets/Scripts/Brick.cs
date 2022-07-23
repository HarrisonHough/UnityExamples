using UnityEngine;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class Brick : MonoBehaviour
    {

        public static int BreakableCount = 0;
        public GameObject smoke;

        [SerializeField]
        private Sprite[] hitSprites;
        private int timesHit;

        [SerializeField]
        private int pointsForBreaking = 5;

        private SpriteRenderer spriteRenderer;
        private bool isBreakable;

        private void Start()
        {
            isBreakable = CompareTag("Breakable");
            timesHit = 0;
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (isBreakable)
            {
                HandleHits();
            }
        }
        
        private void HandleHits()
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                GameManager.Instance.AddToScore(pointsForBreaking);
                KillBlock();
            }
            else
            {
                LoadSprites();
            }
        }
        
        private void LoadSprites()
        {
            int index = timesHit - 1;
            spriteRenderer.sprite = hitSprites[index];
        }
        
        private void KillBlock()
        {
            SpawnParticles();
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            BreakableCount--;

            GameManager.Instance.BrickDestroyed();
        }
        
        private void SpawnParticles()
        {
            GameManager.Instance.ParticleControl.SpawnSmokeParticles(transform.position);
        }
    }
}
