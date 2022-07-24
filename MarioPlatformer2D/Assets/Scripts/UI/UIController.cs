using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI coinsText;
    [SerializeField]
    private TextMeshProUGUI worldText;
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private TextMeshProUGUI livesText;

    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject levelCompletePanel;
    [SerializeField]
    private GameObject highScoresPanel;
    [SerializeField]
    private GameObject newGamePanel;

    [SerializeField]
    private ScoreLabel[] scoreLabels;

    private HighScores highScores;
    [SerializeField]
    private TMP_InputField nameInput;

    // Start is called before the first frame update
    private void Start()
    {
        highScores = FindObjectOfType<HighScores>();
        InitializeText();
    }

    private void InitializeText()
    {
        UpdateScoreText(0);
        UpdateCoinsText(0);
        UpdateTimeText(300);
        UpdateLivesText(3);
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "SCORE \n" + score;
    }
    public void UpdateCoinsText(int coins)
    {
        coinsText.text = "COINS \n" + coins;
    }

    public void UpdateTimeText(float timeRemaining)
    {
        timeText.text = "TIME \n" + (int) timeRemaining;
    }
    public void UpdateLivesText(int lives)
    {
        livesText.text = "LIVES \n" + lives;
    }

    public void ToggleGameOverPanel(bool show)
    {
        gameOverPanel.SetActive(show);
    }

    public void ToggleLevelCompletePanel(bool show)
    {
        levelCompletePanel.SetActive(show);
    }
    public void ToggleHighScoresPanel(bool show)
    {
        if (show)
            UpdateHighScores(highScores.highScoreList);
        highScoresPanel.SetActive(show);
    }

    public void ToggleNewGamePanel(bool show)
    {
        newGamePanel.SetActive(show);
    }

    public void RetryButtonClick()
    {
        ToggleGameOverPanel(false);
        ToggleLevelCompletePanel(false);
        ToggleHighScoresPanel(false);
        ToggleNewGamePanel(true);
    }

    public void ScoresButtonClick()
    {
        ToggleGameOverPanel(false);
        ToggleLevelCompletePanel(false);
        ToggleHighScoresPanel(true);
    }
    public void StartButtonClick()
    {
        var playerName = string.IsNullOrEmpty(nameInput.text) ? nameInput.placeholder.GetComponent<TextMeshProUGUI>().text : nameInput.text;
        GameManager.Instance.StartGame(playerName);
        ToggleNewGamePanel(false);
    }

    public void UpdateHighScores(IList<PlayerData> highScoreList)
    {
        if (scoreLabels.Length != highScoreList.Count)
        {
            Debug.LogError("score label array length does not match high score list count");
            Debug.Log("highscorelist count is " + highScoreList.Count + " scorelabels array length is " + scoreLabels.Length);
            return;
        }
        for (int i = 0; i < highScoreList.Count; i++)
        {
            Debug.Log("setting text label " + i);
            scoreLabels[i].nameText.text = highScoreList[i].name;
            scoreLabels[i].scoreText.text = highScoreList[i].score.ToString();
            scoreLabels[i].coinsText.text = highScoreList[i].coins.ToString();
        }
    }
}
