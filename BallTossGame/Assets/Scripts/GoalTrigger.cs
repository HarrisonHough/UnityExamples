using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: Goal Trigger Class 
*/

public class GoalTrigger : MonoBehaviour
{
    public UnityAction OnGoalTrigger;
    private List<Ball> overlapBallList = new List<Ball>();

    private void OnTriggerEnter(Collider other)
    {
        CheckBallCollision(other, true);
    }
    
    private void HandleBallEnter(Ball ball)
    {
        if (!overlapBallList.Contains(ball))
        {
            overlapBallList.Add(ball);
            OnGoalTrigger?.Invoke();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {        
        CheckBallCollision(other, false);
    }

    private void CheckBallCollision(Collider collider, bool isEntering)
    {
        var ball = collider.gameObject.GetComponent<Ball>();
        if (ball == null) 
            return;
        
        if (isEntering)
        {
            HandleBallEnter(ball);
        }
        else
        {
            HandleBallExit(ball);
        }
    }

    private void HandleBallExit(Ball ball)
    {
        if (overlapBallList.Contains(ball))
        {
            overlapBallList.Remove(ball);
        }
    }
}
