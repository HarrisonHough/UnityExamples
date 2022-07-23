using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Keyboard Input Class 
*/

public class KeyboardInput : MonoBehaviour {

    public PlayerMovement playerMovement;
	// Use this for initialization
	void Start () {
       playerMovement =  GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        InputCheck();
	}

    void InputCheck()
    {
        /*
        if (Input.GetKey(KeyCode.D))
        {
            playerMovement.Move(1f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerMovement.Move(-1f);
        }*/

        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerMovement.JumpReleased();

        }
        if (playerMovement == null) return;
        //Debug.Log("is grounded = " + playerMovement.IsGrounded());
        if (playerMovement.IsGrounded())
        {

            //playerMovement.ResetGlidePower();
            playerMovement.GlideRecharge();
            playerMovement.SetMoveDirection();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerMovement.JumpPressed();
            }
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerMovement.JumpPressed();
            }
        }

        //constant move right 
        playerMovement.Move();
    }
}
