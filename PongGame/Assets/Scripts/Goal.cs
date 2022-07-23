using UnityEngine;
using UnityEngine.Serialization;

public class Goal : MonoBehaviour
{
    public PlayerID id;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            HandleBallCollision(ball);
        }
    }

    private void HandleBallCollision(Ball ball)
    {
        ball.Disable();
        GameManager.Instance.AddToPlayerScore(id);
    }

}
