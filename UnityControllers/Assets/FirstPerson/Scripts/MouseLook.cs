using UnityEngine;

namespace FirstPersonController
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivityX = 800;
        [SerializeField] private float mouseSensitivityY = 600;
        [SerializeField] private Transform playerBody;
        private float xRotation;
        private PlayerInput playerInput;

        private void Start()
        {
            playerInput = GetComponentInParent<PlayerInput>();
            Cursor.lockState = CursorLockMode.Locked;
            xRotation = 0;
        }

        private void Update()
        {
            var mouseX = playerInput.MouseInput.x * mouseSensitivityX * Time.deltaTime;
            var mouseY = playerInput.MouseInput.y * mouseSensitivityY * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
