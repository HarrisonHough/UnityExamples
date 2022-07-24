using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Follow Object Class 
*/

public class FollowObject : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    private void Update()
    {
        Vector3 position = transform.position;
        position.x = target.position.x;

        transform.position = position;
    }

}
