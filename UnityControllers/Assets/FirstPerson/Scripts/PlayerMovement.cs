using UnityEngine;

namespace FirstPersonController
{
    [RequireComponent(typeof(GroundCheck))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController controller;

        private const float Gravity = -18.81f;
        private Vector3 velocity;
        private bool isGrounded;

        [SerializeField] private float speed = 12;
        [SerializeField] private float jumpHeight = 3f;
        private PlayerInput playerInput;
        private GroundCheck groundCheck;

        void Awake()
        {
            groundCheck = GetComponent<GroundCheck>();
            playerInput = GetComponent<PlayerInput>();
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            isGrounded = groundCheck.IsGrounded;
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            Vector3 moveVector = transform.right * playerInput.MoveInput.x + transform.forward * playerInput.MoveInput.y;
            controller.Move(moveVector * speed * Time.deltaTime);
            velocity.y += Gravity * Time.deltaTime;
            if (playerInput.Jump && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * Gravity);
                playerInput.ResetJump();
            }
        }

        private void FixedUpdate()
        {
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
