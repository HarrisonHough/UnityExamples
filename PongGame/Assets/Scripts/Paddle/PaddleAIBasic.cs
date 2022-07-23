using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(PaddleMotor))]
public class PaddleAIBasic : MonoBehaviour
{
    [SerializeField]
    private PaddleMotor motor;
    [SerializeField]
    private float precision = 0.2f;
    private Ball ball;
    private Vector3 startPosition;


    private void Start()
    {
        motor = GetComponent<PaddleMotor>();
        ball = FindObjectOfType<Ball>();
        startPosition = transform.position;
    }

    private void Update()
    {
        if (ball == null || !ball.gameObject.activeSelf)
        {
            return;
        }
        motor.MoveToPosition(ball.transform.position);
    }

    private void FollowBall()
    {
        if (Vector3.Distance(ball.transform.position, transform.position) < precision)
        {
            motor.SetDirection(0);
            return;
        }

        if (ball.transform.position.x < transform.position.x)
        {
            motor.SetDirection(-1);
        }
        if (ball.transform.position.x > transform.position.x)
        {
            motor.SetDirection(1);
        }
    }
}
