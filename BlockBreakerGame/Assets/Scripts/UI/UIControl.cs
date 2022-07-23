using UnityEngine;
using UnityEngine.UI;

namespace Blockbreaker
{
    public class UIControl : MonoBehaviour
    {
        [SerializeField]
        private Text startText;

        [SerializeField]
        private GameObject startMenuPanel;
        [SerializeField]
        private GameObject tapToStartPanel;
        [SerializeField]
        private GameObject autoplayPanel;
        [SerializeField]
        private GameObject gameOverPanel;
        [SerializeField]
        private GameObject winPanel;

        [SerializeField]
        private GameObject scorePanel;
        [SerializeField]
        private Text scoreText;
        [SerializeField]
        private Text multiplierText;

        public void HideStartText()
        {
            startText.enabled = false;
        }

        public void EnableStartText()
        {
            startText.enabled = true;
        }

        public void ToggleTapToStartPanel(bool panelEnabled)
        {
            tapToStartPanel.SetActive(panelEnabled);
        }

        public void ToggleStartMenuPanel(bool panelEnabled)
        {
            startMenuPanel.SetActive(panelEnabled);
        }

        public void ToggleGameOverPanel(bool panelEnabled)
        {
            gameOverPanel.SetActive(panelEnabled);
        }

        public void ToggleWinPanel(bool panelEnabled)
        {
            winPanel.SetActive(panelEnabled);
        }

        public void ToggleAutoPlayPanel(bool panelEnabled)
        {
            autoplayPanel.SetActive(panelEnabled);
        }

        public void ToggleScorePanel(bool panelEnabled)
        {
            scorePanel.SetActive(panelEnabled);
        }

        public void SetScoreText(int score)
        {
            scoreText.text = "" + score;
        }

        public void SetMultiplierText(int score)
        {
            multiplierText.text = "x" + score;
        }
    }
}
