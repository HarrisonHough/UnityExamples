using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    
    public PlayerID Id;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            HandleBallCollision(ball);
        }
    }


    private void HandleBallCollision(Ball ball)
    {
        ball.Disable();
        GameManager.Instance.AddToPlayerScore(Id);
    }

}
