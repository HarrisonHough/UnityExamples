using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Touch Input Class 
*/

public class TouchInput : MonoBehaviour {

    public PlayerMovement playerMovement;
    // Use this for initialization
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update () {
        GetTouches();
    }

    void GetTouches()
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

            /*Touch[] touches = Input.touches;
            for (int i = 0; i < Input.touchCount; i++)
            {

            }*/

        }

        if (playerMovement.IsGrounded())
        {

            //playerMovement.ResetGlidePower();
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
        else
        {


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
