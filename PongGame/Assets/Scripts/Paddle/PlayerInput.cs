using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PaddleMotor))]
public class PlayerInput : MonoBehaviour
{
    private PaddleMotor motor;
    public static UnityAction OnActionButton;

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
        motor.SetDirectionY(Input.GetAxis("Vertical"));
        
        if (Input.GetButtonDown("Fire1"))
        {
            OnActionButton?.Invoke();
        }
    }
}
