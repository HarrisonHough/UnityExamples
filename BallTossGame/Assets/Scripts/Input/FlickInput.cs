using System;
using UnityEngine;

public class FlickInput : TouchInput
{
    private bool ballIsGrabbed;
    public static Ball ActiveBall;
    private const int MOUSE_BUTTON_INDEX = 0;
    private const string PLAYER_TAG = "Player";
    private Vector3 lastFramePosition;
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }
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
        if (Input.GetMouseButtonDown(MOUSE_BUTTON_INDEX))
        {
            TouchStart(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(MOUSE_BUTTON_INDEX))
        {
            LastTouchDuration = Time.time - TouchStartTime;
            var delta = Input.mousePosition - lastFramePosition;
            Debug.Log($"Delta = {delta}");
            TouchRelease(Input.mousePosition, delta);
        }

        if (Input.GetMouseButton(MOUSE_BUTTON_INDEX))
        {
            TouchHold(Input.mousePosition);
        }
        lastFramePosition = Input.mousePosition;
    }

    protected override void HandleTouches()
    {
        Touch[] touches = Input.touches;
        if (touches.Length > 0)
        {
            HandleTouch(touches[0]);
        }
    }

    protected override void TouchStart(Vector3 touchPosition)
    {
        base.TouchStart(touchPosition);
        ActiveBall = null;
        Ray ray = camera.ScreenPointToRay(StartPoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag.Contains(PLAYER_TAG))
            {
                ActiveBall = hit.transform.gameObject.GetComponent<Ball>();
                ballIsGrabbed = true;
            }
        }
    }

    protected override void TouchRelease(Vector3 touchPosition, Vector3 deltaPosition)
    {
        base.TouchRelease(touchPosition, deltaPosition);
        var distanceY = (EndPoint.y - StartPoint.y) / Screen.height;

        var speedY = distanceY / LastTouchDuration;

        var distanceX = (EndPoint.x - StartPoint.x) / Screen.width;

        var speedX = Mathf.Abs(distanceX / LastTouchDuration);

        Debug.Log($"speedY = {speedY} distanceY = {distanceY}");
        Debug.Log($"lastTouchDuration = {LastTouchDuration}");
        Debug.Log($"speedX = {speedY} distanceX = {distanceX}");
        ballIsGrabbed = false;
        var dragVector = CalculateDragVector();
        dragVector.x = dragVector.x.Remap(0, Screen.width, 0, 1) * (1 + speedX);
        dragVector.y = dragVector.y.Remap(0, Screen.height, 0, 1) * (1 + speedY);
        if (ActiveBall != null && Vector3.Distance(StartPoint, EndPoint) > MinimumSwipeDistance)
        {
            ActiveBall.Shoot(dragVector);
        }
        else
        {
            Debug.Log("Swipe was less than minimum swipe distance");
        }
    }
}
