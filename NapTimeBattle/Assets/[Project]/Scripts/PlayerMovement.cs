using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _acceleration = 10;
    private Vector2 _targetVelocity;
    private Rigidbody2D _rb;
    private InputAction _moveAction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _moveAction = GetComponent<PlayerInput>().actions.FindAction("Move");
    }


    private void FixedUpdate()
    {
        _targetVelocity = _moveAction.ReadValue<Vector2>();
        _rb.velocity = Vector2.Lerp(_rb.velocity, _targetVelocity * _speed, Time.deltaTime * _acceleration);
    }
}
