using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class ObjectMovement : MonoBehaviour
{
    [SerializeField]
    private Vector2[] localWaypoints;
    private Vector3[] globalWaypoints;

    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private bool cyclic;
    [SerializeField]
    private float waitTime;
    [Range(0, 2)]
    public float easeAmount;
    private float nextMoveTime;
    private int fromWaypointIndex;
    private float percentBetweenWaypoints;

    private Vector3 velocity;
    private Rigidbody2D objectRigidbody;

    private void Awake()
    {
        globalWaypoints = new Vector3[localWaypoints.Length];
        for (var i = 0; i < globalWaypoints.Length; i++)
        {
            globalWaypoints[i] = (Vector3) localWaypoints[i] + transform.position;
        }
        objectRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        velocity = CalculatePlatformMovement();
    }

    private void FixedUpdate()
    {
        objectRigidbody.MovePosition(transform.position + velocity);
    }

    private Vector3 CalculatePlatformMovement()
    {
        if (Time.time < nextMoveTime)
        {
            return Vector3.zero;
        }

        fromWaypointIndex %= globalWaypoints.Length;
        var toWaypointIndex = (fromWaypointIndex + 1) % globalWaypoints.Length;

        var distanceBetweenWaypoints = Vector3.Distance(globalWaypoints[fromWaypointIndex], globalWaypoints[toWaypointIndex]);
        percentBetweenWaypoints += Time.deltaTime * speed / distanceBetweenWaypoints;
        percentBetweenWaypoints = Mathf.Clamp01(percentBetweenWaypoints);
        var easedPercentBetweenWaypoints = Ease(percentBetweenWaypoints);

        Vector3 newPos = Vector3.Lerp(globalWaypoints[fromWaypointIndex], globalWaypoints[toWaypointIndex], easedPercentBetweenWaypoints);

        if (percentBetweenWaypoints >= 1)
        {

            percentBetweenWaypoints = 0;
            fromWaypointIndex++;
            //have to reverse array order if cyclic
            if (!cyclic)
            {
                if (fromWaypointIndex >= globalWaypoints.Length - 1)
                {
                    fromWaypointIndex = 0;
                    Array.Reverse(globalWaypoints);
                }
            }
            nextMoveTime = Time.time + waitTime;
        }

        return newPos - transform.position;
    }

    private float Ease(float x)
    {
        var a = easeAmount + 1;
        return Mathf.Pow(x, a) / (Mathf.Pow(x, a) + Mathf.Pow(1 - x, a));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        const float size = 0.3f;

        for (var i = 0; i < localWaypoints.Length; i++)
        {
            Vector3 globalWaypointPosition = (Application.isPlaying) ? globalWaypoints[i] : (Vector3) localWaypoints[i] + transform.position;
            Gizmos.DrawLine(globalWaypointPosition - Vector3.up * size, globalWaypointPosition + Vector3.up * size);
            Gizmos.DrawLine(globalWaypointPosition - Vector3.left * size, globalWaypointPosition + Vector3.left * size);
        }
    }
}
