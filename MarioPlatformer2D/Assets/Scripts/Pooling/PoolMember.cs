using System;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Pool Member Class
*/

public class PoolMember : MonoBehaviour
{
    public event Action OnDestroyEvent;

    private void OnDisable()
    {
        OnDestroyEvent?.Invoke();
    }
}
