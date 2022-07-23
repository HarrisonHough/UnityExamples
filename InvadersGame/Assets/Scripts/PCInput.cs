using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: PC Input Class 
*/

public class PCInput : MonoBehaviour {

    [SerializeField]
    private bool mouseInput = true;
    private Movement movement;
	// Use this for initialization
	void Start () {
        movement = GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () {

        if (mouseInput)
        {
            MouseControls();
        }
        else
            KeyboardControls();
	}

    void MouseControls()
    {
        //print("Mouse Position " + Input.mousePosition);
        if (Input.GetMouseButton(1))
            movement.Move(Input.mousePosition);
        else if (Input.GetMouseButtonUp(1))
            movement.MoveBack();

    }

    void KeyboardControls()
    {
        float xAxis = Input.GetAxis("Horizontal");
        if (xAxis != 0)
        {
            movement.MoveX(xAxis);
        }
    }
}
