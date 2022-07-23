using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Switch Class 
*/

public class Switch : MonoBehaviour
{

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Animator bridge;
    private static readonly int SwitchOn = Animator.StringToHash("SwitchOn");
    private static readonly int BridgeOut = Animator.StringToHash("BridgeOut");

    private void Reset()
    {
        if (anim == null)
            anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerSwitch();
        }
    }

    void TriggerSwitch()
    {
        Debug.Log("Switch Triggered");

        // Play switch animation or particles
        if (anim != null)
            anim.SetBool(SwitchOn, true);

        // Run function on Trigger
        bridge.SetBool(BridgeOut, true);
    }
}
