using UnityEngine;

namespace FirstPersonController
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private Transform groundCheck;
        private float groundDistance = 0.4f;
        public LayerMask groundMask;
        public bool IsGrounded => Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}