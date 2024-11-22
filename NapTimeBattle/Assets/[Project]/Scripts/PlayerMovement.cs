using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _aimContainer;
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
        print(_rb.velocity.Get8AxisValue());
        // _aimContainer.right.Get8AxisValue();
    }
}



public static class Vector2Utils
{
    public static Vector3 Get8AxisValue(this Vector3 value)
    {
        Debug.Log("Value : " + value);
        Vector3 toReturn = Vector2.zero;
        if (value.x < -.5f) value.x = -1;
        if (value.x < 0f && value.x > -.5f) value.x = -.5f;
        if (value.x < -.5f && value.x > 0) value.x = 0;

        if (value.x > .5f) value.x = 1;
        if (value.x > 0f && value.x < .5f) value.x = .5f;
        if (value.x > .5f && value.x < 0) value.x = 0;

        if (value.y < -.5f) value.y = -1;
        if (value.y < 0f && value.y > -.5f) value.y = -.5f;
        if (value.y < -.5f && value.y > 0) value.y = 0;

        if (value.y > .5f) value.y = 1;
        if (value.y > 0f && value.y < .5f) value.y = .5f;
        if (value.y > .5f && value.y < 0) value.y = 0;
        value = toReturn;
        return value;
    }

    public static Vector2 Get8AxisValue(this Vector2 value)
    {
        Debug.Log(value);
        Vector3 toReturn = Vector2.zero;
        if (value.x < -.5f) value.x = -1;
        if (value.x < 0f && value.x > -.5f) value.x = -.5f;
        if (value.x < -.5f && value.x > 0) value.x = 0;

        if (value.x > .5f) value.x = 1;
        if (value.x > 0f && value.x < .5f) value.x = .5f;
        if (value.x > .5f && value.x < 0) value.x = 0;

        if (value.y < -.5f) value.y = -1;
        if (value.y < 0f && value.y > -.5f) value.y = -.5f;
        if (value.y < -.5f && value.y > 0) value.y = 0;

        if (value.y > .5f) value.y = 1;
        if (value.y > 0f && value.y < .5f) value.y = .5f;
        if (value.y > .5f && value.y < 0) value.y = 0;
        return toReturn;
    }
}