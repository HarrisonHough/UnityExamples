using System.Collections;
using UnityEngine;

public enum GameState { InMenu, InGame, Finished }
public enum PlayerID { P1, P2 };

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField]
    private int maxScore = 10;
    private GameScene gameScene;
    public GameState state;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnGameSceneStart(GameScene newGameScene)
    {

        gameScene = newGameScene;
        state = GameState.InMenu;
        StopAllCoroutines();
        StartCoroutine(GameRoutine());
    }

    private bool CheckForWinner()
    {
        return gameScene.Player1.Score >= maxScore || gameScene.Player2.Score >= maxScore;
    }

    public void AddToPlayerScore(PlayerID id)
    {
        if (id == PlayerID.P1)
        {
            gameScene.Player1.AddToScore();
        }
        else
        {
            gameScene.Player2.AddToScore();

        }

        gameScene.GameUI.UpdateScores(gameScene.Player1.Score, gameScene.Player2.Score);
    }

    private IEnumerator GameRoutine()
    {
        yield return WaitForStart();
        yield return RunCountdown();
        yield return WaitForWinner();
        yield return GameOver();
    }

    private IEnumerator WaitForStart()
    {
        while (state == GameState.InGame)
        {
            yield return null;
        }
    }

    private IEnumerator RunCountdown()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator WaitForWinner()
    {
        while (CheckForWinner() == false)
        {
            yield return null;
        }

        if (gameScene.Player1.Score >= maxScore)
        {
            //winner is player 1
        }
        else
        {
            //winner is player 2
        }
    }

    private IEnumerator GameOver()
    {
        while (state == GameState.Finished)
        {
            yield return null;
        }
    }
}
