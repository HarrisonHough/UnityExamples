using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Player Class 
*/

public class Player : MonoBehaviour
{
    private int score;

    private SoundManager soundControl;

    private void Start()
    {
        soundControl = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            CoinCollected(other.gameObject);
        }
        else if (other.CompareTag("Danger"))
        {
            Death();
        }
    }

    public int GetScore()
    {
        return score;
    }

    private void CoinCollected(GameObject coin)
    {
        score++;
        soundControl.PlayCoinCollect();
        Destroy(coin);
    }

    private void Death()
    {
        soundControl.PlayDeath();
        gameObject.SetActive(false);
    }
}
