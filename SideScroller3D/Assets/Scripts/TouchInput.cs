using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Touch Input Class 
*/

public class TouchInput : MonoBehaviour
{

    public PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        GetTouches();
    }

    private void GetTouches()
    {

        if (Input.touchCount > 0)
        {
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    //TouchStart();
                    break;
                case TouchPhase.Ended:
                    TouchEnd();
                    break;
            }
        }

        if (playerMovement.IsGrounded)
        {
            playerMovement.GlideRecharge();
            playerMovement.SetMoveDirection();

            if (Input.touchCount > 0)
            {
                switch (Input.GetTouch(0).phase)
                {
                    case TouchPhase.Began:
                        TouchStart();
                        break;
                    case TouchPhase.Ended:
                        TouchEnd();
                        break;
                }
            }
        }
        playerMovement.Move();
    }

    private void TouchStart()
    {
        playerMovement.JumpPressed();
    }

    private void TouchEnd()
    {
        playerMovement.JumpReleased();
    }
}
