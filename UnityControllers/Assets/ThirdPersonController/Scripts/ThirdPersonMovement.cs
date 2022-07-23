using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    private const float CHECK_RADIUS = 0.4f;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpHeight = 3f;
    private const float TURN_SMOOTH_TIME = 0.1f;
    private float turnSmoothVelocity;
    private const float GRAVITY = -9.81f;
    private Vector3 velocity;

    private void Update()
    {
        bool isGrounded = Physics.CheckSphere(groundCheck.position, CHECK_RADIUS, groundMask);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                TURN_SMOOTH_TIME);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection * speed * Time.deltaTime);
        }

        if (isGrounded && controller.velocity.y < 0)
        {
            velocity.y = -2;
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * GRAVITY);
        }

        velocity.y += GRAVITY * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
