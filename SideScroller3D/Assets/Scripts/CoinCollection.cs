using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Coin COllection Class 
*/

public class CoinCollection : MonoBehaviour
{

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
    }

    void CoinCollected(GameObject coin)
    {
        //add to score

        //play sound
        soundControl.PlayCoinCollect();
        //destroy coin
        Destroy(coin);
    }
}
