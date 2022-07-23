using UnityEngine;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        private float _constantSpeed = 10f;

        private Vector3 _lastFrameVelocity;
        private Rigidbody2D _rigidbody2D;

        private Player _player;
        private Vector3 _playerOffset;

        private bool _active = false;

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();

            _player = FindObjectOfType<Player>();
            _playerOffset = transform.position - _player.transform.position;
            ResetBall();
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartBallMovement()
        {
            transform.parent = null;
            _rigidbody2D.velocity = new Vector3(_constantSpeed, _constantSpeed, 0);
            _active = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            _lastFrameVelocity = _rigidbody2D.velocity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!_active)
                return;

            
            Bounce(collision.contacts[0].normal);
            if (collision.gameObject.tag == "Player")
            {
                //set multiplier to 0
                GameManager.Instance.ResetScoreMultiplier();
                
            }
            else if (collision.gameObject.tag == "Breakable")
            {
                //add to multiplier
                GameManager.Instance.IncreaseScoreMultiplier();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collisionNormal"></param>
        private void Bounce(Vector3 collisionNormal)
        {
            
            var direction = Vector3.Reflect(_lastFrameVelocity.normalized, collisionNormal);


            //Debug.Log("Out Direction: " + direction);
            Vector3 velocity = Vector3.zero;
            velocity.x = _constantSpeed;
            velocity.y = _constantSpeed;
            if (direction.x < 0)
            {
                velocity.x *= -1;
            }
            if (direction.y < 0)
            {
                velocity.y *= -1;
            }
            _rigidbody2D.velocity = velocity;
            //rb.velocity = direction * Mathf.Max(speed, minVelocity);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ResetBall()
        {
            _active = false;
            _rigidbody2D.velocity = Vector3.zero;
            transform.position = _player.transform.position + _playerOffset;
            transform.parent = _player.transform;
        }
    }

    
}