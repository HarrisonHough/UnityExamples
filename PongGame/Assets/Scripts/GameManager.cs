using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {InMenu,InGame, Finished}
//used to ID which player has scored the goal
public enum PlayerID { P1, P2 };
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField]
    private int _maxScore = 10;
    private GameScene GameScene;
    public GameState State;

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
            return;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="gameScene"></param>
    public void OnGameSceneStart(GameScene gameScene)
    {
        //set reference to scene
        this.GameScene = gameScene;
        //reset game state
        State = GameState.InMenu;
        StopAllCoroutines();
        StartCoroutine(GameRoutine());
    }

    private bool CheckForWinner()
    {
        if (GameScene.Player1.Score >= _maxScore || GameScene.Player2.Score >= _maxScore)
        {
            return true;
        }
        return false;
    }

    public void AddToPlayerScore(PlayerID id)
    {
        if (id == PlayerID.P1)
        {
            GameScene.Player1.AddToScore();
        }
        else
        {
            GameScene.Player2.AddToScore();

        }

        //update UI
        GameScene.GameUI.UpdateScores(GameScene.Player1.Score, GameScene.Player2.Score);
    }

    IEnumerator GameRoutine()
    {
        yield return WaitForStart();
        yield return RunCountdown();
        yield return WaitForWinner();
        yield return GameOver();

    }

    IEnumerator WaitForStart()
    {
        while (State == GameState.InGame)
        {
            yield return null;
        }
    }

    IEnumerator RunCountdown()
    {
        //3
        yield return new WaitForSeconds(1);
        //2
        yield return new WaitForSeconds(1);
        //1
        yield return new WaitForSeconds(1);
        //go
    }

    IEnumerator WaitForWinner()
    {
        while (CheckForWinner() == false)
        {
            yield return null;
        }

        if (GameScene.Player1.Score >= _maxScore)
        {
            //winner is player 1
        }
        else
        {
            //winner is player 2
        }
        
    }

    IEnumerator GameOver()
    {
        while(State == GameState.Finished)
        {
            yield return null;
        }
        
    }
}
