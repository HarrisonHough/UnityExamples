using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Player Movement Class 
*/

public class PlayerMovement : MonoBehaviour {

    CharacterController controller;
    [SerializeField]
    public float moveSpeed = 0.2f;
    [SerializeField]
    public float jumpSpeed = 0.5f;
    [SerializeField]
    public float gravity = 1f;
    private float glideSpeed = 2f;
    [SerializeField]
    private float glidePowerMax = 2f;
    private bool glide = false;

    private float glidePower;
    private Vector3 moveDirection;
    public LayerMask mask;
    private UIController UIControl;

    [SerializeField]
    float minJumpVelocity = 0.1f;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        UIControl = FindObjectOfType<UIController>();
        moveDirection = new Vector3(0, 0, 0);
        glidePower = glidePowerMax;
        UIControl.ResetGliderBar(glidePowerMax);
    }

    public void SetMoveDirection()
    {
        moveDirection = transform.forward * moveSpeed;
        //Debug.Log("Set move dir = " + moveDirection);
    }
    public void Move()
    {
        //Debug.Log("Moving char = " + moveDirection);


        if (moveDirection.y < 0 && glide)
        {
            // moveDirection.y -= (gravity /2) * Time.deltaTime;
            moveDirection.y = -glideSpeed * Time.deltaTime;
            Glide();
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        //moveDirection.y = rb.velocity.y;
        controller.Move(moveDirection);
        //rb.AddForce(-transform.up * gravity);
    }

    public void JumpPressed()
    {
        if(IsGrounded())
            Jump();
        GlideSwitch(true);
    }

    public void JumpReleased()
    {
        GlideSwitch(false);
        ResetGlidePower();
        
    }
    public void GlideRecharge()
    {
        glidePower += Time.deltaTime;
        glidePower = Mathf.Clamp(glidePower, 0, glidePowerMax);

        UIControl.SetGliderBar(glidePower);
    }

    private void Glide()
    {

        glidePower -= Time.deltaTime;
        UIControl.SetGliderBar(glidePower);
        if (glidePower <= 0)
        {
            glide = false;
            Debug.Log("Glide power = 0 or less");
        }
    }

    private void ResetGlidePower()
    {
        glidePower = glidePowerMax;
        UIControl.ResetGliderBar(glidePowerMax);
    }

    private void GlideSwitch(bool on)
    {
        glide = on;
    }

    private void Jump()
    {
        moveDirection.y += jumpSpeed;
    }

    public bool IsGrounded()
    {
        return controller.isGrounded;
    }

    public void OnCollisionEnter(Collision collision)
    {
        RaycastHit hit;
        //moveDirection.y = 0;
        if (Physics.Raycast(transform.position, transform.up, out hit, 1.0f, mask))
        {
            Debug.Log("Player Hit Head, move down");
            if (moveDirection.y > 0)
                moveDirection.y = 0;
        }
    }

    IEnumerator ConstantMove()
    {
        bool moving = true;
        while (moving)
        {
            Move();
            yield return null;
        }

    }
}
