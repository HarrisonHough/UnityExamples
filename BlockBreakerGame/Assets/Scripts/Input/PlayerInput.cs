using System.Collections;
using System.Collections.Generic;
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
        private InputType _inputType;
        [SerializeField]
        private Player _player;
        

        private Vector3 _startMousePos;

        /// <summary>
        /// Use this for initialization
        /// </summary>
        void Start()
        {
            if (_player == null)
            {
                _player = FindObjectOfType<Player>();
            }
        }

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        void Update()
        {
            if (_player.AutoPlayActive)
                return;

            InputCheck();

        }

        /// <summary>
        /// 
        /// </summary>
        void InputCheck()
        {
            switch (_inputType)
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

                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void MouseKeyboardCheck()
        {
            if (Input.GetMouseButton(0))
            {
                _player.Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }

            if (Input.GetMouseButtonUp(0) && GameManager.Instance._waitingForInput)
            {
                GameManager.Instance._waitingForInput = false;
                //click detected while waiting for input
                GameManager.Instance.Ball.StartBallMovement();
                GameManager.Instance.UIControl.ToggleTapToStartPanel(false);
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void MouseJoystick()
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

        /// <summary>
        /// 
        /// </summary>
        void TouchCheck()
        {
            if (Input.touchCount > 0)
            {

                _player.Move(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
                //Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                //paddle.transform.position = Vector3.Lerp(paddle.transform.position, targetPosition, );
            }
            else
            {
                _player.Stop();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void TouchJoystickCheck()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    TouchBegan();
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    _player.Move(touch.deltaPosition);
                    //TouchMoved(touch.deltaPosition);

                }
            }
        }

        //TODO remove this
        void TouchBegan()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        void MouseDown()
        {
            _startMousePos = Input.mousePosition;
        }

        /// <summary>
        /// 
        /// </summary>
        void MouseHold()
        {
            float deltaX = Input.mousePosition.x - _startMousePos.x;
            deltaX = Mathf.Clamp(deltaX, -2, 2);
            Vector2 delta = new Vector2(deltaX, 0f);
            _player.Move(delta);
            Debug.Log("moving with mouse");
        }

        /// <summary>
        /// 
        /// </summary>
        void MouseUp()
        {

        }
    }

}