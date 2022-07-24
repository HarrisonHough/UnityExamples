using System;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private Transform groundCheckObject;
    private CharacterController characterController;
    [SerializeField]
    private float radius = 0.3f;
    [SerializeField]
    private LayerMask groundLayer;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public bool IsGrounded()
    {
        if (characterController == null)
            return Physics.CheckSphere(groundCheckObject.position, radius, groundLayer);
        return Physics.CheckSphere(groundCheckObject.position, radius, groundLayer) || characterController.isGrounded;
    }
}
