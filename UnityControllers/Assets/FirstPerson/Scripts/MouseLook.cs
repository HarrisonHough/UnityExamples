using UnityEngine;


namespace FirstPersonController
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivityX = 800;
        [SerializeField] private float mouseSensitivityY = 600;
        [SerializeField] private Transform playerBody;
        private float xRotation = 0f;
        private PlayerInput playerInput;

        // Start is called before the first frame update
        void Start()
        {
            playerInput = GetComponentInParent<PlayerInput>();
            Cursor.lockState = CursorLockMode.Locked;
            xRotation = 0;
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = playerInput.MouseInput.x * mouseSensitivityX * Time.deltaTime;
            float mouseY = playerInput.MouseInput.y * mouseSensitivityY * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
