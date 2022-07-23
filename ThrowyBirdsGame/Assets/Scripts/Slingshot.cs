using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2019
* VERSION: 1.0
* SCRIPT: Slingshot Class
*/

public class Slingshot : MonoBehaviour
{
    //store reference to currently "loaded" bird
    [FormerlySerializedAs("_birdToThrow"), SerializeField]
    private Bird birdToThrow;
    public Bird BirdToThrow => birdToThrow;

    //reference to slingshot launch point
    [FormerlySerializedAs("_launchPoint"), SerializeField]
    private Transform launchPoint;

    //adjustable throw force
    [FormerlySerializedAs("_throwForce"), SerializeField]
    private float throwForce = 6f;
    private SlingshotState state;


    [FormerlySerializedAs("_dragThreshold"), SerializeField]
    private float dragThreshold = 1.5f;

    //used to keep track of current bird in bird array
    private int birdArrayIndex;

    [FormerlySerializedAs("_level"), SerializeField]
    private Level level;

    //time it takes for next bird to be loaded into slingshot
    [SerializeField]
    private float reloadTime = 2f;

    [FormerlySerializedAs("trailrenderers"), SerializeField]
    private GameObject[] trailRenderers;
    private int currentTrail;

    private void Start()
    {
        if (level == null)
        {
            level = FindObjectOfType<Level>();
        }
        state = SlingshotState.Idle;

        //TODO possibly move somewhere better
        birdToThrow = level.Birds[birdArrayIndex];
    }

    /// <summary>
    /// Called on mouse/touch down (from InputManager)
    /// </summary>
    public void OnMouseDown()
    {
        if (state == SlingshotState.Idle)
            state = SlingshotState.UserPulling;
    }

    /// <summary>
    /// Called on mouse down/hold (from InputManager)
    /// Calls pullback function
    /// </summary>
    /// <param name="mousePosition">Takes in mouse position to calculate pullback</param>
    public void OnMouseHold(Vector3 mousePosition)
    {
        if (state == SlingshotState.UserPulling)
            PullBack(mousePosition);
    }

    /// <summary>
    /// Called on Touch/Mouse release (from InputController)
    /// Calculates drag distance and calls/cancels bird throw
    /// </summary>
    /// <param name="mousePosition"></param>
    public void OnMouseRelease(Vector3 mousePosition)
    {
        if (state != SlingshotState.UserPulling)
            return;
        var distance = Vector3.Distance(launchPoint.position, birdToThrow.transform.position);
        if (distance > dragThreshold)
        {
            ThrowBird(distance);
            state = SlingshotState.BirdFlying;
            GetNextBird();
        }
        else
        {
            //cancel throw
            //TODO Move Back to position
            birdToThrow.transform.position = launchPoint.position;
            state = SlingshotState.Idle;
        }
    }

    /// <summary>
    /// Calculates throw velocity and calls OnThrow method on current
    /// birdToThrow
    /// </summary>
    /// <param name="distance"></param>
    public void ThrowBird(float distance)
    {
        //calculate velocity
        Vector3 velocity = launchPoint.position - birdToThrow.transform.position;
        //apply multipliers
        Vector2 throwVelocity = new Vector2(velocity.x, velocity.y) * throwForce * distance;

        //clear all trails on through
        HideAllTrails();
        birdToThrow.OnThrow(throwVelocity, trailRenderers[currentTrail]);

        currentTrail++;
        if (currentTrail >= trailRenderers.Length)
        {
            currentTrail = 0;
        }
    }

    private void HideAllTrails()
    {
        foreach (GameObject trailRenderer in trailRenderers)
        {
            trailRenderer.GetComponent<TrailRenderer>().Clear();
        }
    }

    public void PullBack(Vector3 mousePosition)
    {
        Vector3 position = mousePosition;
        position.z = 0;

        if (Vector3.Distance(position, launchPoint.position) > 1.5f)
        {
            Vector3 maxPosition = (position - launchPoint.position).normalized * 1.5f + launchPoint.position;
            birdToThrow.transform.position = maxPosition;
        }
        else
        {
            birdToThrow.transform.position = position;
        }
    }

    /// <summary>
    /// Gets next bird in array and reloads
    /// </summary>
    private void GetNextBird()
    {
        birdArrayIndex++;
        //check if within array range
        if (birdArrayIndex >= level.Birds.Length)
        {
            //no more birds
            //game over (wait for score)
            return;
        }
        //assign next bird
        birdToThrow = level.Birds[birdArrayIndex];
        state = SlingshotState.Reloading;

        //start reload process
        StartCoroutine(ReloadRoutine());
    }

    /// <summary>
    /// Coroutine the moves next bird into slingshot launch position
    /// </summary>
    /// <returns></returns>
    private IEnumerator ReloadRoutine()
    {
        //move using DoTween move
        //TOOD fix below
        birdToThrow.transform.DOMove(launchPoint.transform.position, reloadTime);
        //calculate time to wait
        var timeToWait = Time.time + reloadTime;
        //wait until time passed
        while (timeToWait > Time.time)
        {
            yield return null;
        }
        //now ready to throw again
        state = SlingshotState.Idle;
    }
}
