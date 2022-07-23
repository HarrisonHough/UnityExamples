using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2019
* VERSION: 1.0
* SCRIPT: UIControl Class
*/

public class UIControl : MonoBehaviour
{
    [FormerlySerializedAs("_levelFailedPanel"), SerializeField]
    private GameObject levelFailedPanel;
    [FormerlySerializedAs("_levelCompletePanel"), SerializeField]
    private GameObject levelCompletePanel;
    [FormerlySerializedAs("_finalScore"), SerializeField]
    private Text finalScore;

    public void SetFinalScore(int score)
    {
        finalScore.text = score.ToString();
    }

    public void ToggleLevelFailed(bool enable)
    {
        levelFailedPanel.SetActive(enable);
    }

    public void ToggleLevelComplete(bool enable)
    {
        levelCompletePanel.SetActive(enable);
    }

    public void PauseButtonPress()
    {

    }

    public void RestartButtonPress()
    {
        GameManager.Instance.ReloadCurrentScene();
    }

    public void NextButtonPress()
    {
        GameManager.Instance.LoadNextScene();
    }

    public void LoadScene(int index)
    {
        //load home menu screen
        GameManager.Instance.LoadScene(index);
    }
}
