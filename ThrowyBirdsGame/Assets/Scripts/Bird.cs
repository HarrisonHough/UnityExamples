using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2019
* VERSION: 1.0
* SCRIPT: Bird Class
*/

public class Bird : MonoBehaviour
{
    private Rigidbody2D birdRigidbody2D;
    private CircleCollider2D circleCollider2D;
    [FormerlySerializedAs("BirdLayer")] public LayerMask birdLayer;

    public float Mass { get; set; }

    [SerializeField]
    private float disableDelay = 3f;
    private bool hasHitGround = false;

    private PhysicsMaterial2D birdMaterial;

    private GameObject trail;

    // Start is called before the first frame update
    private void Start()
    {
        birdRigidbody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    /// <summary>
    /// Runs on every collison with this object
    /// Used to start DisableAfterDelay coroutine
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Brick") || collision.gameObject.CompareTag("Pig"))
        {
            //before disable unparent trailrenderer
            if (trail != null)
            {
                trail.transform.parent = null;
                trail = null;
            }
        }

        if (!collision.gameObject.CompareTag("Ground") || hasHitGround) return;
        hasHitGround = true;
        StartCoroutine(DisableAfterDelay());
    }

    /// <summary>
    /// Checks if cursor is currently over this physics object
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public bool IsCursorOverBird(Vector3 location)
    {
        if (circleCollider2D == Physics2D.OverlapPoint(location, birdLayer))
        {
            Debug.Log("TRUE");
            return true;
        }
        Debug.Log("FALSE");
        return false;
    }

    public void OnThrow(Vector2 velocity, GameObject newTrail)
    {
        birdRigidbody2D.isKinematic = false;

        GetComponent<Rigidbody2D>().velocity = velocity;

        trail = newTrail;
        trail.transform.position = transform.position;
        trail.transform.parent = transform;
        var thisTrail = trail.GetComponent<TrailRenderer>();
        thisTrail.Clear();
        thisTrail.enabled = true;
    }

    /// <summary>
    /// This routine slows down and destroys/disables 
    /// this game object after a delay
    /// </summary>
    /// <returns></returns>
    private IEnumerator DisableAfterDelay()
    {
        while (birdRigidbody2D.velocity.y != 0)
        {
            yield return null;
        }

        var timeToDisable = Time.time + 2;
        while (timeToDisable > Time.time)
        {
            yield return null;
        }

        Vector3 startVelocity = birdRigidbody2D.velocity;
        //wait until velocity is slow
        while (Mathf.Abs(birdRigidbody2D.velocity.x) > 0.5)
        {
            Debug.Log("Waiting to slow down");
            birdRigidbody2D.velocity = birdRigidbody2D.velocity * 0.95f * Time.deltaTime;
            yield return null;
        }
        //wait few seconds
        timeToDisable = Time.time + disableDelay;
        Debug.Log("now wait " + timeToDisable + " seconds");
        while (timeToDisable > Time.time)
        {
            yield return null;
        }

        //TODO notify GameManager
        GameManager.Instance.DestroyBird();
        gameObject.SetActive(false);
    }
}
