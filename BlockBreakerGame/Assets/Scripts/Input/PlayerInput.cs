using UnityEngine;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerInput : MonoBehaviour
    {
        private enum InputType { MouseKeyboard, MouseJoystick, Touch, TouchJoystick };
        [SerializeField]
        private InputType inputType;
        [SerializeField]
        private Player player;


        private Vector3 startMousePos;
        
        private void Start()
        {
            if (player == null)
            {
                player = FindObjectOfType<Player>();
            }
        }
        
        private void Update()
        {
            if (player.autoPlayActive)
                return;

            InputCheck();

        }
        
        private void InputCheck()
        {
            switch (inputType)
            {
                case InputType.MouseKeyboard:
                    MouseKeyboardCheck();
                    break;
                case InputType.MouseJoystick:

                    break;
                case InputType.Touch:
                    TouchCheck();
                    break;
                case InputType.TouchJoystick:
                    TouchJoystickCheck();
                    break;
            }
        }

        private void MouseKeyboardCheck()
        {
            if (Input.GetMouseButton(0))
            {
                player.Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }

            if (Input.GetMouseButtonUp(0) && GameManager.Instance.waitingForInput)
            {
                GameManager.Instance.waitingForInput = false;
                //click detected while waiting for input
                GameManager.Instance.Ball.StartBallMovement();
                GameManager.Instance.UIControl.ToggleTapToStartPanel(false);

            }
        }
        
        private void MouseJoystick()
        {
            if (Input.mousePosition.y < Screen.height * 0.8)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    MouseDown();
                }
                else if (Input.GetMouseButton(0))
                {
                    MouseHold();
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    MouseUp();
                }
            }
        }

        private void TouchCheck()
        {
            if (Input.touchCount > 0)
            {

                player.Move(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
                //Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                //paddle.transform.position = Vector3.Lerp(paddle.transform.position, targetPosition, );
            }
            else
            {
                player.Stop();
            }
        }
        
        private void TouchJoystickCheck()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    TouchBegan();
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    player.Move(touch.deltaPosition);
                    //TouchMoved(touch.deltaPosition);

                }
            }
        }

        //TODO remove this
        private void TouchBegan()
        {

        }

        private void MouseDown()
        {
            startMousePos = Input.mousePosition;
        }

        private void MouseHold()
        {
            var deltaX = Input.mousePosition.x - startMousePos.x;
            deltaX = Mathf.Clamp(deltaX, -2, 2);
            Vector2 delta = new Vector2(deltaX, 0f);
            player.Move(delta);
            Debug.Log("moving with mouse");
        }

        static void MouseUp()
        {

        }
    }

}
