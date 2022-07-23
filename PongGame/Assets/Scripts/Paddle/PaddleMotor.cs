using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMotor : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _moveSpeed = 5f;
    private BoxCollider2D _collider;

    private float _directionX = 0f;
    private Vector3 _destination;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _destination = transform.position;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_destination);
    }

    public void SetDirection(float xAxisInput)
    {
        _directionX = xAxisInput;
        MoveInDirection(_directionX);
    }

    public void MoveToPosition(Vector3 position)
    {
        Vector3 direction = (position - transform.position).normalized;
        _destination = transform.position + transform.right * direction.x * _moveSpeed * Time.deltaTime;
        _destination.x = Mathf.Clamp(_destination.x, PlaySpace.XMin + (_collider.size.x / 2), PlaySpace.XMax - (_collider.size.x / 2));
    }

    public void MoveInDirection(float MoveDirection)
    {
        _destination = transform.position + transform.right * MoveDirection * _moveSpeed * Time.deltaTime;
        _destination.x = Mathf.Clamp(_destination.x, PlaySpace.XMin + (_collider.size.x / 2), PlaySpace.XMax - (_collider.size.x / 2));
        
    }
}
