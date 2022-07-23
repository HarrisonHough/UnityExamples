using UnityEngine;
using UnityEngine.Serialization;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2019
* VERSION: 1.0
* SCRIPT: Brick Class
*/

/// <summary>
/// 
/// </summary>
public class Brick : MonoBehaviour
{
    [FormerlySerializedAs("_health"), SerializeField]
    private float health = 70f;

    private const float DAMAGE_MULTIPLIER = 10f;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() == null)
            return;

        HandleCollision(collision.gameObject);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    private void HandleCollision(GameObject target)
    {
        var damage = target.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * DAMAGE_MULTIPLIER;

        //check for high damage
        if (damage > 20)
        {
            //audioSource.Play();
            Debug.Log("High Damage!");
        }

        //decrease health
        health -= damage;

        //check health
        if (health <= 0)
        {
            //TODO possibly change
            gameObject.SetActive(false);
        }
    }
}
