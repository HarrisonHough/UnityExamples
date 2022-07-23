using System;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Input Controller Class
*/

/// <summary>
/// Input Controller class handles all of the user Input 
/// (other than UI Events)
/// </summary>
public class InputController : MonoBehaviour
{

    public static Action OnPrimaryFireAction;
    public static Action OnSecondaryFireAction;
    public static Action OnYInputEndAction;

    private bool noInputY;

    public float XInput
    {
        get;
        private set;
    }

    public float YInput
    {
        get;
        private set;
    }

    /// <summary>
    /// Called once per fixed frame
    /// Input is checked in here to ensure that physics are
    /// calculated correctly (player movement collisions)
    /// </summary>
    private void Update()
    {
        KeyboardInput();
    }

    /// <summary>
    /// Listens for Keyboard input
    /// Used for Keyboard control scheme
    /// </summary>
    private void KeyboardInput()
    {

        XInput = Input.GetAxis("Horizontal");
        YInput = Input.GetAxis("Vertical");
        if (!noInputY && YInput < 0.05f)
            OnYInputEndAction?.Invoke();

        if (Input.GetButtonDown("Shoot"))
        {

            OnPrimaryFireAction?.Invoke();
        }

        noInputY = YInput < 0.05f;
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnDestroy()
    {
        //must unsubscribe before destroying
        OnPrimaryFireAction = null;
        OnSecondaryFireAction = null;
    }
}
