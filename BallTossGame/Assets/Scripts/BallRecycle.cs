using System.Collections;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: Ball Recycle Class 
*/

public class BallRecycle : MonoBehaviour
{
    public float recycleTime = 3f;
    private Ball ball;

    private void Awake()
    {
        ball = GetComponent<Ball>();
    }

    public void StartRecycle()
    {
        StartCoroutine(RecycleTimer());
    }

    private IEnumerator RecycleTimer()
    {
        yield return new WaitForSeconds(recycleTime);
        Recycle();
    }

    private void Recycle()
    {
        ball.ResetPosition();
    }
}
