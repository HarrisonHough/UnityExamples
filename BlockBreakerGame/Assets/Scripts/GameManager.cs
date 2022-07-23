using UnityEngine;
using UnityEngine.SceneManagement;

namespace Blockbreaker
{
    public class GameManager : GenericSingleton<GameManager>
    {
        [SerializeField]
        private LevelManager levelManager;
        [SerializeField]
        private Ball ball;
        public Ball Ball => ball;

        [SerializeField]
        private ParticleControl particleControl;
        public ParticleControl ParticleControl => particleControl;

        [SerializeField]
        private UIControl uiControl;
        public UIControl UIControl => uiControl;

        public bool waitingForInput = true;

        private PlayerInput playerInput;

        private int score;
        public int Score => score;

        private int scoreMultiplier;

        private void Start()
        {
            CheckForNullReferences();
        }

        private void CheckForNullReferences()
        {
            if (levelManager == null)
            {
                levelManager = FindObjectOfType<LevelManager>();
            }
            if (ball == null)
            {
                ball = FindObjectOfType<Ball>();
            }
            if (ParticleControl == null)
            {
                particleControl = FindObjectOfType<ParticleControl>();
            }
            if (uiControl == null)
            {
                uiControl = FindObjectOfType<UIControl>();
            }
            if (playerInput == null)
            {
                playerInput = FindObjectOfType<PlayerInput>();
            }
        }
        
        public void BrickDestroyed()
        {
            if (Brick.BreakableCount <= 0)
            {
                LevelComplete();
            }
        }
        
        public void AddToScore(int scoreToAdd)
        {
            //TODO add in score multiplier
            if (scoreMultiplier > 0)
                score += scoreToAdd * scoreMultiplier;
            else
                score += scoreToAdd;
            uiControl.SetScoreText(score);
        }

        public void IncreaseScoreMultiplier()
        {
            scoreMultiplier++;
            uiControl.SetMultiplierText(scoreMultiplier);
        }
        
        public void ResetScoreMultiplier()
        {
            scoreMultiplier = 0;
            uiControl.SetMultiplierText(scoreMultiplier);
        }
        
        public void GameOver(bool win)
        {
            playerInput.enabled = false;
            uiControl.ToggleAutoPlayPanel(false);
            if (win)
            {
                //update save score
                //Do game over lost things

                uiControl.ToggleWinPanel(true);
                return;
            }

            uiControl.ToggleGameOverPanel(true);
        }
        
        public void LoadScene(string name)
        {
            Debug.Log("New Level load: " + name);
            SceneManager.LoadScene(name);
        }
        
        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }
        
        public void QuitRequest()
        {
            Debug.Log("Quit requested");
            Application.Quit();
        }
        
        public void LevelComplete()
        {

            // TODO stop ball movement
            ball.ResetBall();
            //show wave complete and score

            // wait a while then load next level
            levelManager.LoadNextLevel();

            waitingForInput = true;

            UIControl.ToggleTapToStartPanel(true);
        }
    }
}
