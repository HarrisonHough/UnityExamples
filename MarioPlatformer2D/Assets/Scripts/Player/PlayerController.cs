using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public delegate void JumpEvent();
    public JumpEvent OnJumpEvent;
    public delegate void MovementStartEvent(float xInput);
    public MovementStartEvent onMovementStartEvent;
    public delegate void MovementStopEvent();
    public MovementStopEvent onMovementStopEvent;
    public delegate void MovementInputUpdate(float xInput);
    public MovementInputUpdate onMovementInputUpdate;

    private bool isGrounded = false;

    private void Update()
    {
        if (GameManager.Instance.CurrentState != GameState.InGame)
        {
            onMovementInputUpdate?.Invoke(0);
            return;
        }

        var xInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

        onMovementInputUpdate?.Invoke(xInput);

        if (Input.GetKey(KeyCode.A))
        {
            onMovementStartEvent?.Invoke(-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            onMovementStartEvent?.Invoke(1);
        }
        if (Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            onMovementStopEvent?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            onMovementStopEvent?.Invoke();
        }

        if (Input.GetButtonDown("Jump"))
        {
            OnJumpEvent?.Invoke();
        }
    }
}
