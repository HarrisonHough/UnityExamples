using UnityEngine.Events;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: Game Manager Class 
*/

public class GameManager : GenericSingleton<GameManager>
{

    private UIControl uiControl;
    private int score = 0;
    public static UnityAction<int> OnScoreUpdated;

    public override void Awake()
    {
        base.Awake();
    }

    public void UpdateScore(int value)
    {
        score += value;
        OnScoreUpdated?.Invoke(score);
    }

    private void OnDestroy()
    {
        OnScoreUpdated = null;
    }
}
