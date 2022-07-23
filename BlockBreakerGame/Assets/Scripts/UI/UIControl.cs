using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class UIControl : MonoBehaviour
    {
        [SerializeField]
        private Text _startText;

        [SerializeField]
        private GameObject _startMenuPanel;
        [SerializeField]
        private GameObject _tapToStartPanel;
        [SerializeField]
        private GameObject _autoplayPanel;
        [SerializeField]
        private GameObject _gameOverPanel;
        [SerializeField]
        private GameObject _winPanel;

        [SerializeField]
        private GameObject _scorePanel;
        [SerializeField]
        private Text _scoreText;
        [SerializeField]
        private Text _multiplierText;

        // Use this for initialization
        void Start()
        {

        }

        public void HideStartText()
        {
            _startText.enabled = false;
        }

        public void EnableStartText()
        {
            _startText.enabled = true;
        }

        public void ToggleTapToStartPanel(bool enabled)
        {
            _tapToStartPanel.SetActive(enabled);
        }

        public void ToggleStartMenuPanel(bool enabled)
        {
            _startMenuPanel.SetActive(enabled);
        }

        public void ToggleGameOverPanel(bool enabled)
        {
            _gameOverPanel.SetActive(enabled);
        }

        public void ToggleWinPanel(bool enabled)
        {
            _winPanel.SetActive(enabled);
        }

        public void ToggleAutoPlayPanel(bool enabled)
        {
            _autoplayPanel.SetActive(true);
        }

        public void ToggleScorePanel(bool enabled)
        {
            _scorePanel.SetActive(true);
        }

        public void SetScoreText(int score)
        {
            _scoreText.text = "" + score;
        }

        public void SetMultiplierText(int score)
        {
            _multiplierText.text = "x" + score;
        }
    }
}
