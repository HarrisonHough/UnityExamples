using UnityEngine;
using UnityEngine.Serialization;

public class GameScene : MonoBehaviour
{
    [SerializeField]
    private Paddle player1;
    public Paddle Player1 => player1;
    [SerializeField]
    private Paddle player2;
    public Paddle Player2 => player2;
    [SerializeField]
    private Ball ball;
    public Ball Ball => ball;
    [SerializeField]
    private GameUI gameUI;
    public GameUI GameUI { get { return gameUI; } }

    private void Start()
    {
        GameManager.Instance.OnGameSceneStart(this);
    }
}
