﻿using System.Collections;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Game Manager Class (Singleton)
*/

/// <summary>
/// GameManager is the Central "always alive" singleton class responsible for global events and functions
/// </summary>
public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public static int Score;
    public static int LastScore;
    public static int HighScore;

    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private SpawnController spawner;
    [SerializeField]
    private UIControl uiControl;
    [SerializeField]
    private int lives;
    [SerializeField]
    private Player player;

    public SoundController SoundControl { get; private set; }
    private bool gameOver;

    private const string PREF_LAST_SCORE = "LastScore";
    private const string PREF_HIGH_SCORE = "HighScore";


    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Awake()
    {
        EnforceSingleton();
        Initialize();
    }

    /// <summary>
    /// 
    /// </summary>
    private void EnforceSingleton()
    {
        //Enforces singleton so there is only one instance, multiples will self delete.
        //Game Manager kept alive throughout scene changes.
        if (Instance == null)
            Instance = this;
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Initialize()
    {
        if (!PlayerPrefs.HasKey(PREF_LAST_SCORE))
        {
            PlayerPrefs.SetInt(PREF_LAST_SCORE, 0);
            PlayerPrefs.Save();
        }
        else
            LastScore = PlayerPrefs.GetInt(PREF_LAST_SCORE);

        if (!PlayerPrefs.HasKey(PREF_HIGH_SCORE))
        {
            PlayerPrefs.SetInt(PREF_HIGH_SCORE, 0);
            PlayerPrefs.Save();
        }
        else
            HighScore = PlayerPrefs.GetInt(PREF_HIGH_SCORE);

        if (player == null)
            player = FindObjectOfType<Player>();
        player.gameObject.SetActive(false);
        SoundControl = GetComponent<SoundController>();
    }

    /// <summary>
    /// Called on scene start
    /// </summary>
    void Start()
    {
        //check for null references
        //assign if null
        if (spawner == null)
            spawner = FindObjectOfType<SpawnController>();
        if (uiControl == null)
            uiControl = FindObjectOfType<UIControl>();
    }

    /// <summary>
    /// This function controls the asteroid collision event
    /// </summary>
    /// <param name="asteroid"></param>
    public void AsteroidHit(Asteroid asteroid)
    {
        if (!gameOver)
        {
            int type = (int) asteroid.type;
            switch (type)
            {
                case 0:
                    AddScore(10);
                    uiControl.ShowTextAtPosition("" + Global.SMALL_ASTEROID_POINTS, asteroid.transform.position);
                    break;
                case 1:
                    AddScore(25);
                    uiControl.ShowTextAtPosition("" + Global.MEDIUM_ASTEROID_POINTS, asteroid.transform.position);
                    spawner.SpawnSmallAsteroid(asteroid.transform.position);
                    break;
                case 2:
                    AddScore(50);
                    uiControl.ShowTextAtPosition("" + Global.LARGE_ASTEROID_POINTS, asteroid.transform.position);
                    spawner.SpawnMediumAsteroid(asteroid.transform.position);
                    break;

            }
        }
        SoundControl.PlayerExplode();

        Destroy(asteroid.gameObject);
    }

    /// <summary>
    /// Destroys asteroid when it collides with the border
    /// </summary>
    /// <param name="asteroid"></param>
    public void AsteroidHitBorder(Asteroid asteroid)
    {

        //TODO Remove if not needed
        //Destroy(asteroid.gameObject);
    }

    /// <summary>
    /// Adds score to global value and updates UI
    /// </summary>
    /// <param name="scoreToAdd"></param>
    private void AddScore(int scoreToAdd)
    {
        //add to score
        Score += scoreToAdd;

        //update score UI
        uiControl.UpdateScore(Score);

    }

    /// <summary>
    /// Spawns player at zero position
    /// </summary>
    public void SpawnPlayer()
    {
        var playerTransform = player.transform;
        playerTransform.position = new Vector3(0, 0, 0);
        playerTransform.rotation = Quaternion.identity;
        player.gameObject.SetActive(true);
    }

    /// <summary>
    /// Called when players dies this function controls lives count
    /// and player spawning
    /// </summary>
    public void PlayerDeath()
    {
        if (lives > 0)
        {
            lives--;
            uiControl.UpdateLives(lives);
            StartCoroutine(DelaySpawn());
        }
        else
            GameOver();
    }

    /// <summary>
    /// This coroutine is used to spawn the player after a delay (seconds)
    /// </summary>
    /// <returns></returns>
    IEnumerator DelaySpawn()
    {
        //1 second delay
        yield return new WaitForSeconds(1);

        SpawnPlayer();
    }
    
    /// <summary>
    /// Stops spawning and enables Home screen, this function is 
    /// called when the games over
    /// </summary>
    void GameOver()
    {
        gameOver = true;
        spawner.StopSpawning();
        uiControl.ShowHomeScreen();
        CheckForHighScore();
    }

    /// <summary>
    /// 
    /// </summary>
    private void CheckForHighScore()
    {
        if (Score > HighScore)
        {
            SetHighScore();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void SetHighScore()
    {
        HighScore = Score;
        PlayerPrefs.SetInt(PREF_HIGH_SCORE, Score);
        PlayerPrefs.Save();

        uiControl.UpdateHomeUIScores();
    }

    /// <summary>
    /// Resets global values and restarts the game loop
    /// </summary>
    public void StartGame()
    {
        SetLastScore();
        ResetGameValues();
        ResetUIDisplayText();
        SpawnPlayer();
        spawner.StartSpawning();
        gameOver = false;
    }

    /// <summary>
    /// 
    /// </summary>
    private void SetLastScore()
    {
        LastScore = Score;
        PlayerPrefs.SetInt(PREF_LAST_SCORE, LastScore);
        PlayerPrefs.Save();
        uiControl.UpdateHomeUIScores();
    }

    /// <summary>
    /// 
    /// </summary>
    private void ResetGameValues()
    {
        //reset values
        Score = 0;
        lives = 3;
    }

    /// <summary>
    /// 
    /// </summary>
    private void ResetUIDisplayText()
    {
        //reset ui display text
        uiControl.UpdateScore(0);
        uiControl.UpdateLives(3);
    }

    /// <summary>
    /// Loads scores from file and assigns it to global variables
    /// </summary>
    public void LoadScores()
    {
        if (PlayerPrefs.HasKey(PREF_LAST_SCORE))
        {
            LastScore = PlayerPrefs.GetInt(PREF_LAST_SCORE);
        }
        if (PlayerPrefs.HasKey(PREF_HIGH_SCORE))
        {
            HighScore = PlayerPrefs.GetInt(PREF_HIGH_SCORE);
        }
    }
}
