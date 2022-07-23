using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class GameManager : GenericSingleton<GameManager>
    {
        [SerializeField]
        private LevelManager _levelManager;
        [SerializeField]
        private Ball _ball;
        public Ball Ball { get { return _ball; } }

        [SerializeField]
        private ParticleControl _particleControl;
        public ParticleControl ParticleControl { get { return _particleControl; } }

        [SerializeField]
        private UIControl _uiControl;
        public UIControl UIControl { get { return _uiControl; } }

        public bool _waitingForInput = true;

        private PlayerInput _playerInput;

        private int _score = 0;
        public int Score { get{ return _score; } }

        private int _scoreMultiplier = 0;

        //public bool WaitingForInput { get { return waitingForInput; } }

        /// <summary>
        /// Use this for initialization
        /// </summary>
        void Start()
        {
            CheckForNullReferences();
        }

        /// <summary>
        /// 
        /// </summary>
        void CheckForNullReferences()
        {
            if (_levelManager == null)
            {
                _levelManager = FindObjectOfType<LevelManager>();
            }
            if (_ball == null)
            {
                _ball = FindObjectOfType<Ball>();
            }
            if (ParticleControl == null)
            {
                _particleControl = FindObjectOfType<ParticleControl>();
            }
            if (_uiControl == null)
            {
                _uiControl = FindObjectOfType<UIControl>();
            }
            if (_playerInput == null)
            {
                _playerInput = FindObjectOfType<PlayerInput>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void BrickDestroyed()
        {
            if (Brick.BreakableCount <= 0)
            {
                LevelComplete();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scoreToAdd"></param>
        public void AddToScore(int scoreToAdd)
        {
            //TODO add in score multiplier
            if (_scoreMultiplier > 0)
                _score += scoreToAdd * _scoreMultiplier;
            else
                _score += scoreToAdd;
            //update score
            _uiControl.SetScoreText(_score);
        }

        /// <summary>
        /// 
        /// </summary>
        public void IncreaseScoreMultiplier()
        {
            _scoreMultiplier++;
            _uiControl.SetMultiplierText(_scoreMultiplier);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ResetScoreMultiplier()
        {
            _scoreMultiplier = 0;
            _uiControl.SetMultiplierText(_scoreMultiplier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="win"></param>
        public void GameOver(bool win)
        {
            //disable player input
            _playerInput.enabled = false;
            _uiControl.ToggleAutoPlayPanel(false);
            if (win)
            {
                //update save score
                //Do game over lost things
                
                _uiControl.ToggleWinPanel(true);
                return;
            }

            //update save score
            //Display game over 
            _uiControl.ToggleGameOverPanel(true);
            //Do game over lost things
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void LoadScene(string name)
        {
            Debug.Log("New Level load: " + name);
            SceneManager.LoadScene(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        /// <summary>
        /// 
        /// </summary>
        public void QuitRequest()
        {
            Debug.Log("Quit requested");
            Application.Quit();
        }

        /// <summary>
        /// 
        /// </summary>
        public void LevelComplete()
        {

            // TODO stop ball movement
            _ball.ResetBall();
            //show wave complete and score

            // wait a while then load next level
            _levelManager.LoadNextLevel();

            _waitingForInput = true;

            UIControl.ToggleTapToStartPanel(true);
        }
    }
}
