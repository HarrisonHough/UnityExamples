using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Camera Follow Class 
*/

public class CameraFollow : MonoBehaviour
{

    public Transform player;

    private void LateUpdate()
    {
        if (player == null) return;
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
