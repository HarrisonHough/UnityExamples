using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2019
* VERSION: 1.0
* SCRIPT: GameManager Class
*/

/// <summary>
/// 
/// </summary>
public class GameManager : GenericSingleton<GameManager>
{
    [FormerlySerializedAs("CurrentState")] public GameState currentState;
    private Level currentLevel;

    private int birdsDestroyed;
    private int enemiesKilled;

    private bool levelComplete;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="level"></param>
    public void OnLevelStart(Level level)
    {
        currentLevel = level;

        Reset();
    }

    /// <summary>
    /// 
    /// </summary>
    private void Reset()
    {
        birdsDestroyed = 0;
        enemiesKilled = 0;
        levelComplete = false;
        StartCoroutine(GameLoop());
    }

    /// <summary>
    /// 
    /// </summary>
    public void DestroyBird()
    {
        birdsDestroyed++;
    }

    /// <summary>
    /// 
    /// </summary>
    public void KillEnemy()
    {
        enemiesKilled++;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator GameLoop()
    {
        currentState = GameState.InGame;

        yield return GameRoutine();
        if (!levelComplete)
        {
            yield return LevelFailedRoutine();
        }
        else
        {
            yield return LevelCompleteRoutine();
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator GameRoutine()
    {
        while (birdsDestroyed < currentLevel.Birds.Length && enemiesKilled < currentLevel.Enemies.Length)
        {
            yield return null;
        }

        if (enemiesKilled == currentLevel.Enemies.Length)
        {
            //level complete
            levelComplete = true;
        }

        currentState = GameState.GameOver;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator LevelFailedRoutine()
    {
        //show gameOver UI
        currentLevel.UIControl.ToggleLevelFailed(true);
        yield return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator LevelCompleteRoutine()
    {
        //show gameOver UI
        currentLevel.UIControl.ToggleLevelComplete(true);
        yield return null;
    }

    /// <summary>
    /// 
    /// </summary>
    public void ReloadCurrentScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// 
    /// </summary>
    public void LoadNextScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
    /// <param name="sceneName"></param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
