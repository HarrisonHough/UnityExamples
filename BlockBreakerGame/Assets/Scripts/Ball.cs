using UnityEngine;

namespace Blockbreaker
{
    public class Ball : MonoBehaviour
    {
        private const string PLAYER_TAG = "Player";
        private const string BREAKABLE_TAG = "Breakable";
        [SerializeField]
        private float constantSpeed = 10f;

        private Vector3 lastFrameVelocity;
        private Rigidbody2D ballRigidbody;

        private Player player;
        private Vector3 playerOffset;

        private bool active;
        
        private void Start()
        {
            ballRigidbody = GetComponent<Rigidbody2D>();

            player = FindObjectOfType<Player>();
            playerOffset = transform.position - player.transform.position;
            ResetBall();
        }
        
        public void StartBallMovement()
        {
            transform.parent = null;
            ballRigidbody.velocity = new Vector3(constantSpeed, constantSpeed, 0);
            active = true;
        }
        
        private void Update()
        {
            lastFrameVelocity = ballRigidbody.velocity;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!active)
                return;


            Bounce(collision.contacts[0].normal);
            if (collision.gameObject.CompareTag(PLAYER_TAG))
            {
                GameManager.Instance.ResetScoreMultiplier();
            }
            else if (collision.gameObject.CompareTag(BREAKABLE_TAG))
            {
                GameManager.Instance.IncreaseScoreMultiplier();
            }
        }
        
        private void Bounce(Vector3 collisionNormal)
        {
            var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

            Vector3 velocity = Vector3.zero;
            velocity.x = constantSpeed;
            velocity.y = constantSpeed;
            if (direction.x < 0)
            {
                velocity.x *= -1;
            }
            if (direction.y < 0)
            {
                velocity.y *= -1;
            }
            ballRigidbody.velocity = velocity;
            //rb.velocity = direction * Mathf.Max(speed, minVelocity);
        }
        
        public void ResetBall()
        {
            active = false;
            ballRigidbody.velocity = Vector3.zero;
            transform.position = player.transform.position + playerOffset;
            transform.parent = player.transform;
        }
    }
}
