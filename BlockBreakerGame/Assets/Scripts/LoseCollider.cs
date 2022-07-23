using UnityEngine;

namespace Blockbreaker
{
    public class LoseCollider : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameManager.Instance.GameOver(false);
        }
    }
}
