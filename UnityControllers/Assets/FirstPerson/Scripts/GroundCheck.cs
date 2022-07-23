using UnityEngine;

namespace FirstPersonController
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private Transform groundCheck;
        private const float GROUND_DISTANCE = 0.4f;
        public LayerMask groundMask;
        public bool IsGrounded => Physics.CheckSphere(groundCheck.position, GROUND_DISTANCE, groundMask);
    }
}
