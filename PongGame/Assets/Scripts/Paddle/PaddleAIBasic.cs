using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PaddleMotor))]
public class PaddleAIBasic : MonoBehaviour
{
    [SerializeField]
    private PaddleMotor _motor;
    [SerializeField]
    private float _precision = 0.2f;
    private Ball _ball;
    private Vector3 _startPosition;
    
    
    private void Start()
    {
        _motor = GetComponent<PaddleMotor>();
        _ball = FindObjectOfType<Ball>();
        _startPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (_ball == null || !_ball.gameObject.activeSelf)
        {
            //move to start position
            return;
        }
        _motor.MoveToPosition(_ball.transform.position);
        //FollowBall();

    }

    private void FollowBall()
    {
        if (Vector3.Distance(_ball.transform.position, transform.position) < _precision)
        {
            _motor.SetDirection(0);
            return;
        }
            
        if (_ball.transform.position.x < transform.position.x)
        {
            _motor.SetDirection(-1);
        }
        if (_ball.transform.position.x > transform.position.x)
        {
            _motor.SetDirection(1);
        }

    }
}
