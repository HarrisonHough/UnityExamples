﻿using System.Collections;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Missile Class
*/

/// <summary>
/// Missile Class handles the collision events and destruction
/// of missiles
/// </summary>
public class Missile : MonoBehaviour
{
    public float maxDuration = 10f;
    private const string ENEMY_TAG = "Enemy";

    void OnEnable()
    {
        StartCoroutine(DestroyTimer());
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy();
    }

    /// <summary>
    /// Triggers HitAsteroid function on collision with asteroid
    /// </summary>
    /// <param name="other">Collider : The collider of the object trigger</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains(ENEMY_TAG))
        {
            Destroy();
        }
    }


    IEnumerator DestroyTimer()
    {
        float time = 0;
        while (time < maxDuration)
        {
            time += Time.deltaTime;
            yield return null;
        }
        
        Destroy();
    }

    void Destroy()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);

    }

}
