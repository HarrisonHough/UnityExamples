using UnityEngine;

public class PaddleMotor : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D paddleRigidbody2D;
    [SerializeField]
    private float moveSpeed = 5f;
    private BoxCollider2D paddleCollider;

    private float directionX;
    private float directionY;
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
    
    public void SetDirectionY(float yAxisInput)
    {
        directionY = yAxisInput;
        MoveInDirectionY(directionY);
    }
    public void MoveInDirectionY(float moveDirection)
    {
        destination = transform.position + transform.up * moveDirection * moveSpeed * Time.deltaTime;
        destination.y = Mathf.Clamp(destination.y, PlaySpace.MinY + (paddleCollider.size.y / 2), PlaySpace.MaxY - (paddleCollider.size.y / 2));
    }

    public void SetDirectionX(float xAxisInput)
    {
        directionX = xAxisInput;
        MoveInDirectionX(directionX);
    }

    public void MoveToPosition(Vector3 position)
    {
        Vector3 direction = (position - transform.position).normalized;
        destination = transform.position + transform.right * direction.x * moveSpeed * Time.deltaTime;
        destination.x = Mathf.Clamp(destination.x, PlaySpace.MinX + (paddleCollider.size.x / 2), PlaySpace.MaxX - (paddleCollider.size.x / 2));
    }

    public void MoveInDirectionX(float moveDirection)
    {
        destination = transform.position + transform.right * moveDirection * moveSpeed * Time.deltaTime;
        destination.x = Mathf.Clamp(destination.x, PlaySpace.MinX + (paddleCollider.size.x / 2), PlaySpace.MaxX - (paddleCollider.size.x / 2));
    }
}
