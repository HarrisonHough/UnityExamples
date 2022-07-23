using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D ballRigidbody;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float speed = 6f;
    
    private void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBallWithVelocity();
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = ballRigidbody.velocity;
        velocity.x = Mathf.Clamp(velocity.x, -speed, speed);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var paddle = collision.gameObject.GetComponent<Paddle>();
        if (paddle == null) return;
        
        var yDirection = 1f;
        //if this ball is below paddle at collision then it must
        //be heading back in -y direction
        if (transform.position.y < paddle.transform.position.y)
            yDirection = -1;

        //calculate direction
        Vector2 direction = new Vector2(BounceFactor(paddle.transform.position, paddle.SizeX), yDirection).normalized;
        ballRigidbody.velocity = direction * speed;
    }

    private float BounceFactor(Vector2 paddlePosition, float paddleWidth)
    {
        return (transform.position.x - paddlePosition.x) / paddleWidth;
    }

    public void SpawnBallWithVelocity()
    {
        ballRigidbody.velocity = Vector2.zero;
        transform.position = spawnPoint.position;
        gameObject.SetActive(true);
        ballRigidbody.velocity = RandomStartDirection() * speed;
    }

    private Vector2 RandomStartDirection()
    {
        var randomDirection = 1f;
        
        if (Random.Range(0, 2f) < 1)
        {
            randomDirection = -1;
        }

        var newVelocity = new Vector2(0, randomDirection * speed);
        //get random X amount
        randomDirection = Random.Range(-1f, 1f);
        newVelocity.x = randomDirection * speed;

        var pythagoras = ((newVelocity.x * newVelocity.x) + (newVelocity.y * newVelocity.y));
        if (pythagoras > (speed * speed))
        {
            float magnitude = Mathf.Sqrt(pythagoras);
            float multiplier = speed / magnitude;
            newVelocity.x *= multiplier;
            newVelocity.y *= multiplier;
        }

        return newVelocity.normalized;
    }

    public void Disable()
    {
        ballRigidbody.velocity = Vector2.zero;
        gameObject.SetActive(false);
        transform.position = spawnPoint.position;
    }
}
