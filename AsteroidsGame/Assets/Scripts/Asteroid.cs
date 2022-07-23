using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Asteroid Class 
*/

/// <summary>
/// Asteroid class controls the collision events on the
/// asteroids in the game
/// </summary>
public class Asteroid : Enemy
{

    public AsteroidType type;
    public static int CurrentAsteroidCount;
    public static int TotalAsteroidCount;

    /// <summary>
    /// Run on game start
    /// </summary>
    protected override void Start()
    {
        base.Start();
        CurrentAsteroidCount++;
        TotalAsteroidCount++;

    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                Hit();
                break;
            case "Missile":
                HitByMissile();
                break;
            case "Border":
                BorderHit();
                break;
            case "Enemy":
                Hit();
                break;
            default:
                //Hit();
                break;
        }
    }

    /// <summary>
    /// Triggers events when colliding with objects
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        CurrentAsteroidCount--;


        switch (other.tag)
        {
            case "Player":
                Hit();
                break;
            case "Missile":
                HitByMissile();
                break;
            case "Border":
                BorderHit();
                break;
            case "Enemy":
                Hit();
                break;
            default:
                //Hit();
                break;

        }
    }

    /// <summary>
    /// Hides object and triggers Asteroid Hit function in GameManager
    /// </summary>
    private void HitByMissile()
    {
        GameManager.Instance.AsteroidHit(this);
        Destroy();
    }

    /// <summary>
    /// Hides object and triggers Asteroid Hit function in GameManager
    /// </summary>
    private void Hit()
    {
        GameManager.Instance.SoundControl.PlayerExplode();
        Destroy();

    }

    /// <summary>
    /// Hides object and trigger Border Hit function in GameManager
    /// </summary>
    private void BorderHit()
    {
        Destroy();
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

}
