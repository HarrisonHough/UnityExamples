using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D ballRigidbody;
    [SerializeField]
    private float speed = 6f;
    private Vector3 spawnPosition;
    private void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;
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

    public void Disable()
    {
        ballRigidbody.velocity = Vector2.zero;
        gameObject.SetActive(false);
        transform.position = spawnPosition;
    }
}
