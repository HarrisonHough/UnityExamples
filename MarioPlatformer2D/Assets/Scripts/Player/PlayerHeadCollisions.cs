using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerHeadCollisions : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var destructible = collision.gameObject.GetComponent<IDestructible>();
        if (destructible == null || !(collision.gameObject.transform.position.y > transform.position.y)) return;
        destructible.Destroy();
        //TODO improve logic for determining score
        player.AddToScore(100);
    }
}
