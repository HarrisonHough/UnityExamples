using UnityEngine;
using UnityEngine.Events;

public class BallSpawner : MonoBehaviour
{
    
    private Rigidbody2D ballRigidbody;
    [SerializeField]
    private Transform spawnPoint;
    public Vector3 SpawnPosition => spawnPoint.position;
    [SerializeField]
    private Ball ballPrefab;
    private Ball ball;
    
    [SerializeField]
    private float ballSpeed = 6f;
    
    private void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        PlayerInput.OnActionButton += OnActionButton;
    }
    private void OnActionButton()
    {
        //TODO check game mode for other input 
        SpawnBallWithVelocity();
    }

    public void SpawnBallWithVelocity()
    {
        if (ball == null)
        {
            ball = Instantiate(ballPrefab.gameObject, spawnPoint.position, Quaternion.Euler(Vector3.zero)).GetComponent<Ball>();
        }
        ballRigidbody.velocity = Vector2.zero;
        ball.transform.position = spawnPoint.position;
        ball.gameObject.SetActive(true);
        ballRigidbody.velocity = RandomStartDirection() * ballSpeed;
    }
    
    private Vector2 RandomStartDirection()
    {
        var randomDirection = 1f;

        if (Random.Range(0, 2f) < 1)
        {
            randomDirection = -1;
        }

        var newVelocity = new Vector2(0, randomDirection * ballSpeed);
        randomDirection = Random.Range(-1f, 1f);
        newVelocity.x = randomDirection * ballSpeed;

        var pythagoras = ((newVelocity.x * newVelocity.x) + (newVelocity.y * newVelocity.y));
        if (pythagoras > (ballSpeed * ballSpeed))
        {
            float magnitude = Mathf.Sqrt(pythagoras);
            float multiplier = ballSpeed / magnitude;
            newVelocity.x *= multiplier;
            newVelocity.y *= multiplier;
        }
        return newVelocity.normalized;
    }
}
