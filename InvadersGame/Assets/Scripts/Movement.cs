using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Movement Class 
*/
public class Movement : MonoBehaviour {

    public bool lockedYPos = false;
    public float speed = 1f;
    public float zOffset = 1.5f;

	// Use this for initialization
	void Start () {
		
	}
    

    public void Move(Vector3 inputPosition)
    {
        //print(" first move input position" + inputPosition);
        // print("screen to world" + Camera.main.ScreenToWorldPoint(inputPosition));
        inputPosition.z = 10f;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(inputPosition);
        targetPosition.y = 0;
        targetPosition.z = 0;
        if (!lockedYPos)
            targetPosition.z = zOffset;

        print("target Position is " + targetPosition);

        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);


    }

    public void MoveX(float xAxis, float xMin, float xMax)
    {
        Vector3 position = transform.position;

        position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        
        //clamp withint bounds
        position.x = Mathf.Clamp(position.x, xMin, xMax);
        transform.position = position;
    }


    public void MoveX(float xAxis)
    {
            transform.position += new Vector3(speed * Time.deltaTime * xAxis, 0.0f, 0.0f);

  
    }

    public void MoveBack()
    {
        Vector3 targetPos = new Vector3(transform.position.x, 0f, 0f);
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);
    }
}
