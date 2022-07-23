using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blockbreaker
{
    public class LoseCollider : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Game over you lose
            GameManager.Instance.GameOver(false);
        }

    }
}
