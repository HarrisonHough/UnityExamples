using UnityEngine;

public class FlickInput : TouchInput
{
    private bool ballIsGrabbed;
    public static Ball ActiveBall;
    private Vector3 lastFramePosition;

    private void Awake()
    {
        ActiveBall = FindObjectOfType<Ball>();
    }
    protected override void Update()
    {
        lastFramePosition = Input.mousePosition;
    }

    public void OnButtonDown()
    {
        TouchStart(Input.mousePosition);
    }

    public void OnButtonUp()
    {
        LastTouchDuration = Time.time - TouchStartTime;
        Vector3 delta = Input.mousePosition - lastFramePosition;
        Debug.Log($"Delta = {delta}");
        TouchRelease(Input.mousePosition, delta);
    }

    public void OnButtonHold()
    {
        TouchHold(Input.mousePosition);
    }
    protected override void TouchStart(Vector3 touchPosition)
    {
        base.TouchStart(touchPosition);
        ballIsGrabbed = true;
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
        Vector3 dragVector = CalculateDragVector();
        dragVector.x = dragVector.x.Remap(0, Screen.width, 0, 1) * (1 + speedX );
        dragVector.y = dragVector.y.Remap(0, Screen.height, 0, 1) * (1 + speedY );
        if (ActiveBall != null && Vector3.Distance(StartPoint, EndPoint) > MinimumSwipeDistance)
        {
            ActiveBall.Shoot(dragVector);
        }
        else
        {
            Debug.Log($"Swipe was less than minimum swipe distance");
        }
    }
}
