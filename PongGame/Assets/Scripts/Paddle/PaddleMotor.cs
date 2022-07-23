using UnityEngine;
using UnityEngine.Serialization;

public class PaddleMotor : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D paddleRigidbody2D;
    [SerializeField]
    private float moveSpeed = 5f;
    private BoxCollider2D paddleCollider;

    private float directionX;
    private Vector3 destination;

    private void Start()
    {
        paddleRigidbody2D = GetComponent<Rigidbody2D>();
        paddleCollider = GetComponent<BoxCollider2D>();
        destination = transform.position;
    }

    private void FixedUpdate()
    {
        paddleRigidbody2D.MovePosition(destination);
    }

    public void SetDirection(float xAxisInput)
    {
        directionX = xAxisInput;
        MoveInDirection(directionX);
    }

    public void MoveToPosition(Vector3 position)
    {
        Vector3 direction = (position - transform.position).normalized;
        destination = transform.position + transform.right * direction.x * moveSpeed * Time.deltaTime;
        destination.x = Mathf.Clamp(destination.x, PlaySpace.MinX + (paddleCollider.size.x / 2), PlaySpace.MaxX - (paddleCollider.size.x / 2));
    }

    public void MoveInDirection(float MoveDirection)
    {
        destination = transform.position + transform.right * MoveDirection * moveSpeed * Time.deltaTime;
        destination.x = Mathf.Clamp(destination.x, PlaySpace.MinX + (paddleCollider.size.x / 2), PlaySpace.MaxX - (paddleCollider.size.x / 2));
    }
}
