using System.Collections;
using UnityEngine;

public enum GameState { InMenu, InGame, Respawning }
public class GameManager : GenericSingleton<GameManager>
{
    public GameState CurrentState { get; private set; }
    public bool IsGameOver { get; private set; }
    public bool IsLevelComplete { get; private set; }

    private Vector3 spawnPoint = Vector3.zero;
    private Player player;
    public UIController UIController { get; private set; }
    public HighScores highScores;
    public Pool destroyParticlesPool;

    private void Start()
    {
        UIController = FindObjectOfType<UIController>();
        highScores = FindObjectOfType<HighScores>();
    }

    public void UpdateSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }

    public void SetPlayer(Player targetPlayer)
    {
        player = targetPlayer;
    }

    public void StartGame(string playerName)
    {
        player.SetPlayerName(playerName);
        StartCoroutine(GameLoop());
    }

    public void GameOver()
    {
        IsGameOver = true;
    }

    public void LevelComplete()
    {
        IsGameOver = true;
        IsLevelComplete = true;
        player.AddToScore(1);
        highScores.AddNewScore(player.PlayerData);
    }

    private IEnumerator GameLoop()
    {
        IsLevelComplete = false;
        IsGameOver = false;
        //need to reset if new game
        spawnPoint = Vector3.zero;
        player.Reset();

        while (!IsGameOver)
        {
            yield return StartCoroutine(LevelLoop());
            if (!IsGameOver)
                yield return new WaitForSeconds(2);
        }
        CurrentState = GameState.InMenu;

        if (IsLevelComplete)
            UIController.ToggleLevelCompletePanel(true);
        else
            UIController.ToggleGameOverPanel(true);
    }

    private IEnumerator LevelLoop()
    {
        player.Respawn(spawnPoint);
        CurrentState = GameState.InGame;
        while (!player.IsDead && !IsGameOver)
        {
            yield return null;
        }
        CurrentState = GameState.Respawning;
    }
}
