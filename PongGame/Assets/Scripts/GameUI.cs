using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI player1Score;
    [SerializeField]
    private TextMeshProUGUI player2Score;

    public void UpdateScores(int score1, int score2)
    {
        player1Score.text = score1.ToString();
        player2Score.text = score2.ToString();
    }
}
