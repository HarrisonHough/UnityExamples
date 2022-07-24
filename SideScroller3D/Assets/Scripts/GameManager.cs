using UnityEngine;
using UnityEngine.SceneManagement;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Game Manager Class 
*/

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    // Use this for initialization
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {

    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadLevel(string levelToLoad)
    {

    }
}
