using UnityEngine;
using UnityEngine.Serialization;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2019
* VERSION: 1.0
* SCRIPT: Input Controller Class
*/

/// <summary>
/// 
/// </summary>
public class InputController : MonoBehaviour
{
    //store reference to slingshot
    [FormerlySerializedAs("_slingshot"), SerializeField]
    private Slingshot slingshot;
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        GetInput();
    }

    /// <summary>
    /// Get user input depending on game state
    /// </summary>
    private void GetInput()
    {
        switch (GameManager.Instance.currentState)
        {
            case GameState.InMenu:
                break;
            case GameState.InGame:
                SlingShotControls();
                break;
            case GameState.GameOver:
                break;
        }
    }

    /// <summary>
    /// Handles input for slingshot control
    /// </summary>
    private void SlingShotControls()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 location = camera.ScreenToWorldPoint(Input.mousePosition);
            if (slingshot.BirdToThrow.IsCursorOverBird(location))
                slingshot.OnMouseDown();

        }
        if (Input.GetMouseButton(0))
        {
            Vector3 location = camera.ScreenToWorldPoint(Input.mousePosition);
            slingshot.OnMouseHold(location);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 location = camera.ScreenToWorldPoint(Input.mousePosition);
            slingshot.OnMouseRelease(location);
        }
    }

    private void CameraMovementControls()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

        }

        if (Input.touchCount == 2)
        {

        }
    }
}
