using System;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    protected Vector3 StartPoint;
    protected Vector3 EndPoint;
    protected float TouchStartTime;
    protected float LastTouchDuration;
    protected Vector3 TouchDeltaPosition;
    protected float MinimumSwipeDistance = 20;
    public static Action<float, Vector3> OnTouchRelease;
    public static Action<Vector3> OnTouchStart;


    protected virtual void Update()
    {
        HandleTouches();
    }
    protected virtual void HandleTouches()
    {
        Touch[] touches = Input.touches;
        if (touches.Length > 0)
        {
            HandleTouch(touches[0]);
        }
    }

    protected virtual void HandleTouch(Touch touch)
    {
        TouchHold(touch.position);
        if (touch.phase == TouchPhase.Began)
        {
            TouchStart(touch.position);
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            EndPoint = touch.position;
            TouchRelease(touch.position, touch.deltaPosition);
        }
    }

    protected virtual void TouchStart(Vector3 touchPosition)
    {
        TouchStartTime = Time.time;
        StartPoint = touchPosition;
    }

    protected virtual void TouchRelease(Vector3 touchPosition, Vector3 deltaPosition)
    {
        EndPoint = touchPosition;
        TouchDeltaPosition = deltaPosition;
        LastTouchDuration = Time.time - TouchStartTime;
    }

    protected virtual void TouchHold(Vector3 touchPosition)
    {
    }

    protected Vector3 CalculateDragVector()
    {
        EndPoint = Input.mousePosition;
        Vector3 dragVector = EndPoint - StartPoint;
        return dragVector;
    }
}
