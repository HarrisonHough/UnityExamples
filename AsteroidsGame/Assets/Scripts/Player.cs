using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2017
* VERSION: 1.0
* SCRIPT: Player Class
*/

/// <summary>
/// Player class controls the collision and movement events of the
/// player object
/// </summary>
/// 
public class Player : MonoBehaviour
{ 
    private Item item;
    private const string ENEMY_TAG = "Enemy";

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Contains(ENEMY_TAG))
        {
            Death();
        }
    }

    /// <summary>
    /// Called on collision to trigger Death function
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ENEMY_TAG))
        {
            Death();
        }
        else if (other.CompareTag("Item"))
        {
            item = other.gameObject.GetComponent<Item>();
            CheckItem();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void CheckItem()
    {
        //TODO move to more appropriate class
        switch (item.type)
        {
            case ItemType.Shield:
                //TurnOnShield();
                break;
            case ItemType.Life:

                break;
            case ItemType.Bomb:

                break;
        }
        item.Destroy();
    }

    /// <summary>
    /// Called PlayerDeath function in GameManager before destroying
    /// self
    /// </summary>
    public void Death()
    {
        GameManager.Instance.PlayerDeath();
        gameObject.SetActive(false);
    }
}
