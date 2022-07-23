using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerController))]
public class PlayerMovement : MonoBehaviour
{
    private const int SPEED_MULTIPLIER = 200;
    [SerializeField]
    private float moveSpeed = 5f;
    private Vector3 targetVelocity;
    private Rigidbody2D playerRigidbody2D;
    private float xInput;
    
    private void Start()
    {
        targetVelocity = Vector3.zero;
        playerRigidbody2D = GetComponent<Rigidbody2D>();

        var playerController = GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.onMovementInputUpdate += UpdateVelocity;
        }
    }

    public void UpdateVelocity(float xInput)
    {
        this.xInput = xInput;
    }

    public void MatchVelocity()
    {

    }

    private void FixedUpdate()
    {
        targetVelocity = Vector2.zero;
        targetVelocity = new Vector2(xInput * moveSpeed * SPEED_MULTIPLIER, playerRigidbody2D.velocity.y);
        playerRigidbody2D.velocity = targetVelocity;
    }
}
