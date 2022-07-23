using System;
using UnityEngine;

namespace FirstPersonController
{
    public class PlayerInput : MonoBehaviour
    {
        public static PlayerInput Instance => instance;
        private static PlayerInput instance;
        private Vector2 moveInput;
        public Vector2 MoveInput => !inputDisabled ? moveInput : Vector2.zero;
        private Vector2 mouseInput;
        public Vector2 MouseInput => !inputDisabled ? mouseInput : Vector2.zero;
        private bool inputDisabled = false;
        public bool InputDisabled => inputDisabled;

        private bool jump;
        public bool Jump => jump && !inputDisabled;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                throw new Exception("There can only be 1 PlayerInput");
            }
        }

        private void Update()
        {
            mouseInput.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            moveInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            jump = Input.GetButtonDown("Jump");
        }

        public void ResetJump()
        {
            jump = false;
        }
    }
}
