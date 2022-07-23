using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float timeRemaining { get; private set; }
    private bool pauseTime;
    public UnityAction onTimerCompleted;

    public void AddTime(float seconds)
    {
        SetDuration(timeRemaining + seconds);
    }

    public void SetDuration(float seconds)
    {
        timeRemaining = seconds;
    }

    public void StartTimer(float seconds)
    {
        StopAllCoroutines();
        SetDuration(seconds);
        StartCoroutine(RunTimerAsync());
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }

    public void ResumeTimer()
    {
        StopAllCoroutines();
        StartCoroutine(RunTimerAsync());
    }

    private IEnumerator RunTimerAsync()
    {
        while (timeRemaining > Mathf.Epsilon)
        {
            if (!pauseTime)
            {
                timeRemaining -= Time.deltaTime;
            }
            yield return null;
        }
        onTimerCompleted?.Invoke();
    }

    private void OnDestroy()
    {
        onTimerCompleted = null;
    }
}
