using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField]
    private Paddle _player1;
    public Paddle Player1 { get { return _player1; } }
    [SerializeField]
    private Paddle _player2;
    public Paddle Player2 { get { return _player2; } }
    [SerializeField]
    private Ball _ball;
    public Ball Ball { get { return _ball; } }
    [SerializeField]
    private GameUI _gameUI;
    public GameUI GameUI { get { return _gameUI; } }

    private void Start()
    {
        GameManager.Instance.OnGameSceneStart(this);
    }

}
