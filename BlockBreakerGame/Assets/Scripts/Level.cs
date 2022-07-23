using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class Level : MonoBehaviour
    {

        public int NumberOfBricks { get; set; }

        /// <summary>
        /// Use this for initialization
        /// Called on game start
        /// </summary>
        void Start()
        {
            if (NumberOfBricks == 0)
            {
                NumberOfBricks = transform.childCount;
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnEnable()
        {
            if (NumberOfBricks == 0)
            {
                NumberOfBricks = transform.childCount;
            }
            Debug.Log("Bricks to break = " + NumberOfBricks);
            Brick.BreakableCount = NumberOfBricks;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Reset()
        {
            NumberOfBricks = transform.childCount;
        }

    }
}
