﻿using UnityEngine;
using UnityEngine.Serialization;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2019
* VERSION: 1.0
* SCRIPT: Enemy Class
*/

public struct DamageState
{
    public Sprite sprite;
    public float healthThreshold;
}

public class Enemy : MonoBehaviour
{
    //adjustable variable for enemy health
    [FormerlySerializedAs("_health"), SerializeField]
    private float health = 150f;

    //References to different damage states
    [SerializeField]
    private DamageState damageState1;
    [SerializeField]
    private DamageState damageState2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() == null)
            return;

        if (collision.gameObject.CompareTag("Bird"))
        {
            GameManager.Instance.KillEnemy();
            gameObject.SetActive(false);
        }
        else
        {
            HandleCollision(collision.gameObject);
        }
    }

    private void HandleCollision(GameObject target)
    {
        var damage = target.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10f;
        if (damage >= 10)
        {
            //play death audio
            //audioSource.Play();
        }

        //decrease health
        health -= damage;

        //TODO implement damage states
        //if (health < changeSpriteHealth)
        //gameObject.GetComponent<SpriteRenderer>().sprite = spriteShownWhenHurt;

        //check health
        if (!(health <= 0)) return;
        //tell GameManeger enemy has died
        GameManager.Instance.KillEnemy();
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
