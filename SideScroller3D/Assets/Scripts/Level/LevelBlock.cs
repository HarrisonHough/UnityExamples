using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Level Block Class 
*/

public class LevelBlock : MonoBehaviour {

    public AttachPoint attachPoint;

	// Use this for initialization
	void Start () {
        attachPoint = GetComponentInChildren<AttachPoint>();	
	}

    public AttachPoint GetAttachPoint()
    {
        attachPoint = GetComponentInChildren<AttachPoint>();
        return attachPoint;
    }

}
