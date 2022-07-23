using UnityEngine;
using UnityEngine.Serialization;

namespace Blockbreaker
{
    public class Player : MonoBehaviour, IMovable<Vector2>
    {
        public bool autoPlayActive;
        [SerializeField]
        private float moveSpeed = 2f;
        private const float PADDLE_SIZE = 0.7f;
        private Transform ball;
        private float currentTime = 0f;

        [FormerlySerializedAs("maxMoveAmout"),SerializeField]
        private float maxMoveAmount = 2f;
        [SerializeField]
        private Vector2 minMaxXPos = new Vector3();

        private void Start()
        {
            ball = FindObjectOfType<Ball>().transform;
        }

        private void Update()
        {
            if (autoPlayActive)
            {
                AutoPlay();
            }
        }
        
        public void ToggleAutoPlay()
        {
            autoPlayActive = !autoPlayActive;
        }
        
        private void AutoPlay()
        {
            var paddlePos = new Vector3(0.5f, transform.position.y, 0f);
            paddlePos.x = Mathf.Clamp(ball.position.x, 0.5f, 15.5f);

            transform.position = paddlePos;
        }
        
        public void Move(Vector2 deltaPosition)
        {
            var deltaX = deltaPosition.x;
            deltaX = Mathf.Clamp(deltaX, -maxMoveAmount, maxMoveAmount);
            Vector3 moveDir = Vector3.right;
            Vector3 newPos = new Vector3(0, 0, 0);
            newPos = transform.position + moveDir * deltaX * Time.deltaTime * moveSpeed;
            newPos.x = Mathf.Clamp(newPos.x, minMaxXPos.x, minMaxXPos.y);
            transform.position = newPos;
        }
        
        private void MoveWithMouse()
        {
            var paddlePos = new Vector3(0.5f, 0.5f, 0f);
            var mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

            paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);

            transform.position = paddlePos;
        }
        
        public void Move(Vector3 targetPosition)
        {
            targetPosition.z = 0;
            targetPosition.y = transform.position.y;
            targetPosition.x = Mathf.Clamp(targetPosition.x, PlaySpace.MinX + (PADDLE_SIZE / 2), PlaySpace.MaxX - (PADDLE_SIZE / 2));
            currentTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
        }
        
        public void Move(float horizontal)
        {
            Vector3 pos = transform.position + Vector3.right * horizontal * moveSpeed * Time.deltaTime;
            pos.x = Mathf.Clamp(pos.x, PlaySpace.MinX + (PADDLE_SIZE / 2), PlaySpace.MaxX - (PADDLE_SIZE / 2));
            transform.position = pos;
        }
        
        public void Stop()
        {
            currentTime = 0;
        }
    }
}
