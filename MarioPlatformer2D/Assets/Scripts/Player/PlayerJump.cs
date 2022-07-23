using UnityEngine;
using UnityEngine.Serialization;

public class PlayerJump : MonoBehaviour
{

    [SerializeField]
    private float jumpPower = 10f;
    public LayerMask platformLayer;

    private Rigidbody2D playerRigidbody2D;
    private CircleCollider2D circleCollider2D;

    public bool IsGrounded { get; private set; }

    private void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        var playerController = GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.OnJumpEvent += Jump;
        }
    }

    public void Jump()
    {
        if (!CheckIsGrounded())
            return;

        playerRigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    public bool CheckIsGrounded()
    {
        var playerBottomLeft = new Vector3(transform.position.x - (circleCollider2D.radius), transform.position.y - (circleCollider2D.radius), 0);
        for (int i = 0; i < 3; i++)
        {
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector3.up), (circleCollider2D.radius) + 0.1f, platformLayer))
                IsGrounded = true;
        }
        return IsGrounded;
    }
}
