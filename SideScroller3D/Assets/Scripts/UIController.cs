using UnityEngine;
using UnityEngine.UI;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: UI Controller Class 
*/


public class UIController : MonoBehaviour
{
    [SerializeField]
    private Slider gliderBar;

    public void ResetGliderBar(float maxValue)
    {
        gliderBar.maxValue = maxValue;
        gliderBar.value = maxValue;
    }

    public void SetGliderBar(float value)
    {
        gliderBar.value = value;
    }
}
