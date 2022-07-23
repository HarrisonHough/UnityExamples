using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickInput : TouchInput
{
    private bool ballIsGrabbed = false;
    public static Ball activeBall;
    private const int MouseButtonIndex = 0;
    private Vector3 lastFramePosition;

    protected override void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        HandleMouseInput();
#else
        HandleTouches();
#endif
    }
    
    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(MouseButtonIndex))
        {
            TouchStart(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(MouseButtonIndex))
        {
            lastTouchDuration = Time.time - touchStartTime;
            var delta = Input.mousePosition - lastFramePosition;
            Debug.Log($"Delta = {delta}");
            TouchRelease(Input.mousePosition,  delta);
        }

        if (Input.GetMouseButton(MouseButtonIndex))
        {
            TouchHold(Input.mousePosition);
        }
        lastFramePosition = Input.mousePosition;
    }
    
    protected override void HandleTouches()
    {
        var touches = Input.touches;
        if (touches.Length > 0)
        {
            HandleTouch(touches[0]);
        }
    }

    protected override void TouchStart(Vector3 touchPosition)
    {
        base.TouchStart(touchPosition);
        activeBall = null;
        Ray ray = Camera.main.ScreenPointToRay(startPoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag.Contains("Player"))
            {
                activeBall = hit.transform.gameObject.GetComponent<Ball>();
                ballIsGrabbed = true;
            }
        }
    }

    protected override void TouchRelease(Vector3 touchPosition, Vector3 deltaPosition)
    {
        base.TouchRelease(touchPosition, deltaPosition);
        var distanceY = (endPoint.y- startPoint.y) / Screen.height;
        
        var speedY = distanceY / lastTouchDuration;
        
        var distanceX = (endPoint.x - startPoint.x) / Screen.width ;

        var speedX = Mathf.Abs(distanceX / lastTouchDuration);
        
        Debug.Log($"speedY = {speedY} distanceY = {distanceY}");
        Debug.Log($"lastTouchDuration = {lastTouchDuration}");
        Debug.Log($"speedX = {speedY} distanceX = {distanceX}");
        ballIsGrabbed = false;
        var dragVector = CalculateDragVector();
        dragVector.x = dragVector.x.Remap(0, Screen.width, 0,1) * (1 + speedX);
        dragVector.y = dragVector.y.Remap(0, Screen.height, 0, 1) * (1 + speedY);
        //dragVector.y += speedY;
        if (activeBall != null && Vector3.Distance(startPoint, endPoint) > minimumSwipeDistance)
        {
            activeBall.Shoot(dragVector);
        }
        else
        {
            Debug.Log("Swip was less than minimum swipe distance");
        }
    }
}
