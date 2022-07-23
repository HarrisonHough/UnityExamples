﻿using System.Collections;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private float shieldDuration;

    private bool isSecondaryFire = false;
    
    private void Awake()
    {
        shield.SetActive(false);
        if (isSecondaryFire)
            InputController.OnSecondaryFireAction += Activate;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Activate()
    {

        StartCoroutine(ShieldOn());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShieldOn()
    {
        shield.SetActive(true);
        yield return new WaitForSeconds(shieldDuration);

        //TODO add warning for when shield about to run out
        shield.SetActive(false);
    }


}
