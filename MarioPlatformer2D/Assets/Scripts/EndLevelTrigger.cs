using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EndLevelTrigger : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains(PLAYER_TAG))
        {
            GameManager.Instance.LevelComplete();
        }
    }
}
