using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: Goal Control Class 
*/

public class GoalControl : MonoBehaviour 
{

    [SerializeField]
    private GameObject[] positions;

    private int positionIndex;
    private GoalTrigger goalTrigger;
    
	void Start () {
        if (positions.Length < 1)
        {
            enabled = false;
            return;
        }

        CheckPositions();
        SetInitialPosition();

	}

    void SetInitialPosition()
    {
        transform.position = positions[positionIndex].transform.position;
    }

    void CheckPositions()
    {
        if (positions.Length < 0)
        {
            Debug.LogError("Goal Positions not set");
        }
    }
    public void GoalScored()
    {
        // TODO: Add to score
        Debug.Log("Goal Scored");
        NextPosition();
    }

    void NextPosition()
    {
        if (positionIndex < positions.Length - 1)
        {
            positionIndex++;
            transform.position = positions[positionIndex].transform.position;
        }
        else
        {
            LastGoalScored();
        }
    }

    void LastGoalScored()
    {
        //TODO refactor
        Debug.Log("Last goal scored");
    }
}
