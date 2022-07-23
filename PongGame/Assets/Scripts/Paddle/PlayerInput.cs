using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PaddleMotor))]
public class PlayerInput : MonoBehaviour
{
    private PaddleMotor _motor;
    // Start is called before the first frame update
    void Start()
    {
        _motor = GetComponent<PaddleMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        _motor.SetDirection(Input.GetAxis("Horizontal"));
    }
}
