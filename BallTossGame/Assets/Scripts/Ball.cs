using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: Ball Class 
*/

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{

    [SerializeField]
    private float xForceScale = 1f;
    [SerializeField]
    private float yForceScale = 0.85f;
    [SerializeField]
    private float zForceScale = 0.65f;
    [SerializeField]
    private float power = 20f;

    [SerializeField] private int pointValue = 1;

    private Rigidbody ballRigidbody;
    private new ConstantForce constantForce;
    private const string GOAL_TAG = "Goal";
    private bool hasScored;

    private Vector3 startPosition;
    private Quaternion startRotation;

    [SerializeField] private float initialAngle = 45;
    [SerializeField] private Transform goalTransform;

    private void Awake()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        ballRigidbody = GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        ballRigidbody.useGravity = true;
        Vector3 direction = new Vector3(0, 1 * yForceScale, 1 * zForceScale);
        ballRigidbody.AddForce(direction);
    }

    private void FixedUpdate()
    {
        if (Wind.WindActive && ballRigidbody.useGravity)
        {
            AddForce(Wind.WindForce);
        }
    }

    public Vector3 CalculateTargetForce(Vector3 force)
    {
        Vector3 targetPosition = goalTransform.position;
        Vector3 ballPosition = transform.position;
        float gravity = Physics.gravity.magnitude;
        float angle = initialAngle * Mathf.Deg2Rad;

        // Positions of this object and the target on the same plane
        Vector3 planarTarget = new Vector3(targetPosition.x, 0, targetPosition.z);
        Vector3 planarPosition = new Vector3(ballPosition.x, 0, ballPosition.z);

        float distance = Vector3.Distance(planarTarget, planarPosition);
        float yOffset = ballPosition.y - targetPosition.y;

        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        // Rotate our velocity to match the direction between the two objects
        float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPosition);
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;


        finalVelocity.x = force.x * power;
        return finalVelocity;
    }

    public void Shoot(Vector3 force)
    {
        if (force.sqrMagnitude < 1)
        {
            return;
        }
        hasScored = false;
        ballRigidbody.useGravity = true;

        ballRigidbody.AddForce(CalculateTargetForce(force) * ballRigidbody.mass, ForceMode.Impulse);
        //AddForce(CalculateForce(force));
        Wind.WindActive = true;
        var ballRecycle = GetComponent<BallRecycle>();
        if (ballRecycle)
        {
            ballRecycle.StartRecycle();
        }
    }

    public void AddForce(Vector3 force)
    {
        ballRigidbody.AddForce(force);
    }

    private Vector3 CalculateForce(Vector3 force)
    {
        var finalForce = new Vector3(
            force.x * xForceScale * power,
            force.y * yForceScale * power,
            force.y * zForceScale * power);
        return finalForce;
    }

    public void DisableGravity()
    {
        Wind.WindActive = false;
        ballRigidbody.useGravity = false;
        ballRigidbody.velocity = Vector3.zero;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains(GOAL_TAG) && !hasScored)
        {
            hasScored = true;
            GameManager.Instance.UpdateScore(pointValue);
        }
    }

    public void ResetPosition()
    {
        DisableGravity();
        ballRigidbody.angularVelocity = Vector3.zero;
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
