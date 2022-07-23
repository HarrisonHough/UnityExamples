using UnityEngine;
using UnityEngine.Serialization;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private string paddleName;
    public string PaddleName => paddleName;
    public float SizeX { get; set; }

    public int Score { get; set; }

    private void Start()
    {
        SizeX = GetComponent<BoxCollider2D>().size.x;
    }

    public void AddToScore()
    {
        Score++;
    }

    public void Reset()
    {
        Score = 0;
    }
}
