using UnityEngine;
using System.Collections;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        private int _levelIndex = 0;
        [SerializeField]
        private Level[] _levelsArray;

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            if (_levelsArray.Length == 0)
            {
                for (int i = 0; i < _levelsArray.Length; i++)
                {
                    _levelsArray[i].gameObject.SetActive(false);
                }
                _levelsArray[0].gameObject.SetActive(true);
            }
            
        }        

        /// <summary>
        /// 
        /// </summary>
        public void LoadNextLevel()
        {
            
            _levelsArray[_levelIndex].gameObject.SetActive(false);
            _levelIndex++;
            if (_levelIndex >= _levelsArray.Length)
            {
                _levelIndex = 0;
                GameManager.Instance.GameOver(true);

                return;
            }
            _levelsArray[_levelIndex].gameObject.SetActive(true);
            Brick.BreakableCount =  _levelsArray[_levelIndex].NumberOfBricks;
            Debug.Log("Breakablecount = " + Brick.BreakableCount);

        }

        /// <summary>
        /// 
        /// </summary>
        private void Reset()
        {
            _levelsArray = new Level[transform.childCount];
            for (int i = 0; i < _levelsArray.Length; i++)
            {
                _levelsArray[i] = transform.GetChild(i).GetComponent<Level>();
                _levelsArray[i].gameObject.SetActive(false);
            }
            _levelsArray[0].gameObject.SetActive(true);
        }

    }
}
