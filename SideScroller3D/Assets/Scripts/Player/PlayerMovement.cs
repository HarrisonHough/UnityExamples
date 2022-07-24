using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Player Movement Class 
*/

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;
    private GroundCheck groundCheck;
    [SerializeField]
    private float moveSpeed = 0.2f;
    private float gravity = -1f;
    private const float GLIDE_SPEED = 2f;
    [SerializeField]
    private float jumpHeight = 3f;
    [SerializeField]
    private float timeToApex =0.4f;
    private float jumpVelocity = 4f;
    [SerializeField]
    private float glidePowerMax = 2f;
    private bool glide;

    private float glidePower;
    private Vector3 moveDirection;
    public LayerMask mask;
    private UIController uiControl;
    public bool IsGrounded => groundCheck.IsGrounded();

    private void Start()
    {
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToApex;
        groundCheck = GetComponent<GroundCheck>();
        controller = GetComponent<CharacterController>();
        uiControl = FindObjectOfType<UIController>();
        moveDirection = new Vector3(0, 0, 0);
        glidePower = glidePowerMax;
        uiControl.ResetGliderBar(glidePowerMax);
    }

    public void SetMoveDirection()
    {
        moveDirection = transform.forward * moveSpeed;
    }
    public void Move()
    {
        if (moveDirection.y < 0 && glide)
        {
            moveDirection.y = -GLIDE_SPEED;
            Glide();
        }
        else
        {
            moveDirection.y += gravity * Time.deltaTime;
        }
        if (groundCheck.IsGrounded() && moveDirection.y < 0)
        {
            moveDirection.y = -1f;
        }

        controller.Move(moveDirection * Time.deltaTime);
    }

    public void JumpPressed()
    {
        if (groundCheck.IsGrounded())
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

        uiControl.SetGliderBar(glidePower);
    }

    private void Glide()
    {
        glidePower -= Time.deltaTime;
        uiControl.SetGliderBar(glidePower);
        if (!(glidePower <= 0)) return;
        glide = false;
        Debug.Log("Glide power = 0 or less");
    }

    private void ResetGlidePower()
    {
        glidePower = glidePowerMax;
        uiControl.ResetGliderBar(glidePowerMax);
    }

    private void GlideSwitch(bool on)
    {
        glide = on;
    }

    private void Jump()
    {
        moveDirection.y = jumpVelocity;
        Debug.Log($"jump vel = {jumpVelocity} move direction = {moveDirection.y}");
    }

    public void OnCollisionEnter(Collision collision)
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, transform.up, out hit, 1.0f, mask)) return;
        Debug.Log("Player Hit Head, move down");
        if (moveDirection.y > 0)
            moveDirection.y = 0;
    }

    private void Update()
    {
        Move();
    }
}
