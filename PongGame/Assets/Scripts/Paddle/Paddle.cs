using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private string _name;
    public string Name { get { return _name; } }
    public float SizeX { get; set; }
    public int Score { get; set; }
    // Start is called before the first frame update
    void Start()
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
