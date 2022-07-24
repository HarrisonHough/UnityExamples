using UnityEngine;

public class Paddle : MonoBehaviour
{
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
