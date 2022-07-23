using UnityEngine;

namespace Blockbreaker
{
    public class Level : MonoBehaviour
    {

        public int NumberOfBricks { get; set; }

        private void Start()
        {
            if (NumberOfBricks == 0)
            {
                NumberOfBricks = transform.childCount;
            }
        }
        
        private void OnEnable()
        {
            if (NumberOfBricks == 0)
            {
                NumberOfBricks = transform.childCount;
            }
            Debug.Log("Bricks to break = " + NumberOfBricks);
            Brick.BreakableCount = NumberOfBricks;
        }
        
        private void Reset()
        {
            NumberOfBricks = transform.childCount;
        }
    }
}
