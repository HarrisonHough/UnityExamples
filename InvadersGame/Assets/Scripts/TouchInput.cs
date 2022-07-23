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

    //private bool touching = false;
    private Movement playerMovement;

	// Use this for initialization
	void Start () {
        playerMovement = GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () {

        GetTouches();
	}

    void GetTouches()
    {
        if (Input.touchCount > 0)
        {

            Touch[] touchArray = Input.touches;
            for (int i = 0; i < Input.touchCount; i++)
            {

                //Check phase
                switch (Input.GetTouch(i).phase)
                {
                    case TouchPhase.Began:

                        TouchStart(i);

                        break;

                    case TouchPhase.Ended:

                        TouchEnd(i);
                        break;
                }
                playerMovement.Move(Input.GetTouch(0).position);
            }

        }
        //No touches detected
        else
        {
            //touching = false;
            playerMovement.MoveBack();
        }
        

    }

    void TouchStart(int touchIndex)
    {
        //touching = true;
        switch (touchIndex)
        {
            //Movement 
            case 0:

                break;

            //Action/shoot
            case 1:

                break;
        }
    }

    void TouchEnd(int touchIndex)
    {

        switch (touchIndex)
        {
            //Movement 
            case 0:

                break;

            //Action/shoot
            case 1:

                break;
        }
    }
}
