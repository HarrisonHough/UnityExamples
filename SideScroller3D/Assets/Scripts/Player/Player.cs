using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Player Class 
*/

public class Player : MonoBehaviour {
    private int score;

    SoundManager soundControl;
    // Use this for initialization
    void Start()
    {
        soundControl = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            CoinCollected(other.gameObject);
        }
        else if (other.tag == "Danger")
        {
            Death();
        }
    }

    public int GetScore()
    {
        return score;
    }
    void CoinCollected(GameObject coin)
    {
        //add to score
        score++;
        //play sound
        soundControl.PlayCoinCollect();
        //destroy coin
        Destroy(coin);
    }

    void Death()
    {
        //GameManager.instance.LoadLevel(0);
        soundControl.PlayDeath();
        gameObject.SetActive(false);
    }
}
