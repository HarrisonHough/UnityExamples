using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Item Class
*/

public enum ItemType { Shield, Bomb, Life };

public class Item : MonoBehaviour
{


    public ItemType type;
    private ConstantVelocity velocity;
    public Vector2 speedRange;

    /// <summary>
    /// Used for initialization
    /// </summary>
    void Start()
    {
        velocity = GetComponent<ConstantVelocity>();
        var speed = Random.Range(speedRange.x, speedRange.y);
        velocity.ConstantSpeed = speed;
    }


    public void Destroy()
    {
        Destroy(gameObject);
    }

}
