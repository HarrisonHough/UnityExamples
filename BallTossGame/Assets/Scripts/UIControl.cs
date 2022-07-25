using UnityEngine;
using UnityEngine.UI;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: UI Control Class 
*/

public class UIControl : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text windText;
    [SerializeField]
    private Image windArrow;
    
    void Start()
    {
        Wind.RandomWindStrength(true);
        UpdateWindPanel();
        GameManager.OnScoreUpdated += UpdateScore;
    }
    
    private void UpdateWindPanel()
    {
        windArrow.transform.rotation = Wind.WindSpeed < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        windText.text = Wind.GetReadableWindSpeed();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
        Wind.RandomWindStrength(true);
        UpdateWindPanel();
    }
}
