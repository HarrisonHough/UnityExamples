using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Switch Class 
*/

public class Switch : MonoBehaviour {

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Animator bridge;

    private void Reset()
    {
        if (anim == null)
            anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TriggerSwitch();
        }
    }

    void TriggerSwitch()
    {
        Debug.Log("Switch Triggered");

        // Play switch animation or particles
        if(anim!= null)
            anim.SetBool("SwitchOn", true);

        // Run function on Trigger
        bridge.SetBool("BridgeOut", true);
    }
}
