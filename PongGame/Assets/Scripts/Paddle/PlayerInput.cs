using UnityEngine;

[RequireComponent(typeof(PaddleMotor))]
public class PlayerInput : MonoBehaviour
{
    private PaddleMotor motor;

    private void Start()
    {
        motor = GetComponent<PaddleMotor>();
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        motor.SetDirection(Input.GetAxis("Horizontal"));
    }
}
