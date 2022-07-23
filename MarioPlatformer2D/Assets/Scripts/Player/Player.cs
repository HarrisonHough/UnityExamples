using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour, IKillable
{
    public string PlayerName { get => PlayerData.name; private set => PlayerData.name = value; }
    public int Score { get => PlayerData.score; private set => PlayerData.score = value; }
    public int Coins { get => PlayerData.coins; private set => PlayerData.coins = value; }

    public PlayerData PlayerData { get; private set; }
    private int lives;
    [SerializeField]
    private int maxLives;

    private float timeRemaining;
    [SerializeField]
    private float maxTime;

    public bool IsDead { get; private set; }

    private UIController uiController;
    private CameraShake cameraShake;
    
    private void Start()
    {
        PlayerData = new PlayerData();
        GameManager.Instance.SetPlayer(this);
        uiController = FindObjectOfType<UIController>();
        cameraShake = FindObjectOfType<CameraShake>();
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentState != GameState.InGame)
            return;
        timeRemaining -= Time.deltaTime;
        uiController.UpdateTimeText(timeRemaining);


        if (timeRemaining <= 0)
        {
            //game over;
            GameManager.Instance.GameOver();
        }
    }

    public void SetPlayerName(string newName)
    {
        PlayerName = newName;
    }

    public void Kill()
    {
        lives--;
        uiController.UpdateLivesText(lives);
        if (lives <= 0)
        {
            GameManager.Instance.GameOver();
            return;
        }
        cameraShake.StartShakeEffect();
        var particles = GameManager.Instance.destroyParticlesPool.GetObject().GetComponent<ParticleEffect>();
        particles.PlayAtPosition(transform.position);
        IsDead = true;
    }

    public void AddToScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        uiController.UpdateScoreText(Score);
    }

    public void Respawn(Vector3 spawnPoint)
    {
        IsDead = false;
        Score = 0;
        timeRemaining = maxTime;
        transform.position = spawnPoint;
    }

    public void Reset()
    {
        Score = 0;
        Coins = 0;
        lives = maxLives;
        timeRemaining = maxTime;
    }
}
