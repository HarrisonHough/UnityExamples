using System;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    protected Vector3 startPoint;
    protected Vector3 endPoint;
    protected float touchStartTime = 0f;
    protected float lastTouchDuration = 0f;
    protected Vector3 touchDeltaPosition;
    protected float minimumSwipeDistance = 20;
    public static Action<float, Vector3> OnTouchRelease;
    public static Action<Vector3> OnTouchStart;


    protected virtual void Update()
    {
        HandleTouches();

    }
    protected virtual void HandleTouches()
    {
        var touches = Input.touches;
        for (int i = 0; i < touches.Length; i++)
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
            endPoint = touch.position;
            TouchRelease(touch.position, touch.deltaPosition);
        }
    }

    protected virtual void TouchStart(Vector3 touchPosition)
    {
        touchStartTime = Time.time;
        startPoint = touchPosition;
    }

    protected virtual void TouchRelease(Vector3 touchPosition, Vector3 deltaPosition)
    {
        endPoint = touchPosition;
        touchDeltaPosition = deltaPosition;
        lastTouchDuration = Time.time - touchStartTime;
    }

    protected virtual void TouchHold(Vector3 touchPosition)
    {
    }

    protected Vector3 CalculateDragVector()
    {
        endPoint = Input.mousePosition;
        Vector3 dragVector = endPoint - startPoint;
        return dragVector;
    }
}
