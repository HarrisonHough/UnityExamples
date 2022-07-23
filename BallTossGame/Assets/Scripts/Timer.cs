using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float TimeRemaining { get; private set; }
    private bool pauseTime;
    public UnityAction OnTimerCompleted;
    public Timer(bool pauseTime)
    {
        this.pauseTime = pauseTime;
    }

    public void AddTime(float seconds)
    {
        SetDuration(TimeRemaining + seconds);
    }

    public void SetDuration(float seconds)
    {
        TimeRemaining = seconds;
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
        while (TimeRemaining > Mathf.Epsilon)
        {
            if (!pauseTime)
            {
                TimeRemaining -= Time.deltaTime;
            }
            yield return null;
        }
        OnTimerCompleted?.Invoke();
    }

    private void OnDestroy()
    {
        OnTimerCompleted = null;
    }
}
