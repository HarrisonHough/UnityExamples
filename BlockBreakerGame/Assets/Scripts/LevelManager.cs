using UnityEngine;

namespace Blockbreaker
{
    public class LevelManager : MonoBehaviour
    {
        private int levelIndex;
        [SerializeField]
        private Level[] levelsArray;
        
        private void Start()
        {
            if (levelsArray.Length != 0) return;
            foreach (Level t in levelsArray)
            {
                t.gameObject.SetActive(false);
            }
            levelsArray[0].gameObject.SetActive(true);
        }

        public void LoadNextLevel()
        {
            levelsArray[levelIndex].gameObject.SetActive(false);
            levelIndex++;
            if (levelIndex >= levelsArray.Length)
            {
                levelIndex = 0;
                GameManager.Instance.GameOver(true);

                return;
            }
            levelsArray[levelIndex].gameObject.SetActive(true);
            Brick.BreakableCount = levelsArray[levelIndex].NumberOfBricks;
            Debug.Log("Breakable count = " + Brick.BreakableCount);
        }
        
        private void Reset()
        {
            levelsArray = new Level[transform.childCount];
            for (var i = 0; i < levelsArray.Length; i++)
            {
                levelsArray[i] = transform.GetChild(i).GetComponent<Level>();
                levelsArray[i].gameObject.SetActive(false);
            }
            levelsArray[0].gameObject.SetActive(true);
        }

    }
}
