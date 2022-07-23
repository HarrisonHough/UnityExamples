using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blockbreaker
{
    public class Player : MonoBehaviour, IMovable<Vector2>
    {
        public bool AutoPlayActive;
        [SerializeField]
        private float moveSpeed = 2f;
        private float paddleSize = 0.7f;
        private Transform ball;
        private float currentTime = 0f;

        [SerializeField]
        private float maxMoveAmout = 2f;
        [SerializeField]
        private Vector2 minMaxXPos = new Vector3();

        /// <summary>
        /// Use this for initialization
        /// </summary>
        void Start()
        {
            ball = FindObjectOfType<Ball>().transform;
        }

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        void Update()
        {

            if (AutoPlayActive)
            {
                AutoPlay();
            }            

        }

        /// <summary>
        /// 
        /// </summary>
        public void ToggleAutoPlay()
        {
            AutoPlayActive = !AutoPlayActive;

        }

        /// <summary>
        /// 
        /// </summary>
        private void AutoPlay()
        {

            Vector3 paddlePos = new Vector3(0.5f, transform.position.y, 0f);
            paddlePos.x = Mathf.Clamp(ball.position.x, 0.5f, 15.5f);

            transform.position = paddlePos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deltaPosition"></param>
        public void Move(Vector2 deltaPosition)
        {
            float deltaX = deltaPosition.x;
            deltaX = Mathf.Clamp(deltaX, -maxMoveAmout, maxMoveAmout);
            Vector3 moveDir = Vector3.right;
            Vector3 newPos = new Vector3(0, 0, 0);
            newPos = transform.position + moveDir * deltaX * Time.deltaTime * moveSpeed;
            newPos.x = Mathf.Clamp(newPos.x, minMaxXPos.x, minMaxXPos.y);
            transform.position = newPos;
        }

        /// <summary>
        /// 
        /// </summary>
        private void MoveWithMouse()
        {
            Vector3 paddlePos = new Vector3(0.5f, 0.5f, 0f);
            float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

            paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);

            transform.position = paddlePos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetPosition"></param>
        public void Move(Vector3 targetPosition)
        {
            targetPosition.z = 0;
            targetPosition.y = transform.position.y;
            targetPosition.x = Mathf.Clamp(targetPosition.x, PlaySpace.xMin+ (paddleSize/2), PlaySpace.xMax - (paddleSize / 2));
            currentTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="horizontal"></param>
        public void Move(float horizontal)
        {
            Vector3 pos = transform.position + Vector3.right * horizontal * moveSpeed * Time.deltaTime;
            pos.x = Mathf.Clamp(pos.x, PlaySpace.xMin + (paddleSize / 2), PlaySpace.xMax - (paddleSize / 2));
            transform.position = pos ;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            currentTime = 0;
        }
    }
}
