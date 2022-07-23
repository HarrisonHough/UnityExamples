using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Camera Follow Class 
*/

public class CameraFollow : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (player == null) return;
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
	}
}
