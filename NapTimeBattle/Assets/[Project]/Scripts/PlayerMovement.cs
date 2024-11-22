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
    private Animator _animator;
    private AnimatorControler _animControler;
    private Vector2 _knockBack;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _animControler = GetComponent<AnimatorControler>();
        _rb = GetComponent<Rigidbody2D>();
        _moveAction = GetComponent<PlayerInput>().actions.FindAction("Move");
    }

    private void FixedUpdate()
    {
        _targetVelocity = _moveAction.ReadValue<Vector2>();
        _rb.velocity = Vector2.Lerp(_rb.velocity, _targetVelocity * _speed + _knockBack, Time.deltaTime * _acceleration);
        _knockBack = Vector2.Lerp(_knockBack, Vector2.zero, Time.deltaTime * 5);
        _aimContainer.right = _rb.velocity.ConvertTo8Direction().normalized;

        Vector2 dir = _rb.velocity.ConvertTo8Direction().normalized;

        if (_rb.velocity.magnitude <= .1f)
            _animControler.SetState(AnimatorControler.IDLE);
        else
            _animControler.SetState(_rb.velocity.x > 0 ? AnimatorControler.MOVE_RIGHT : AnimatorControler.MOVE_LEFT);

        _animator.SetFloat("DirectionX", dir.x);
        _animator.SetFloat("DirectionY", dir.y);
    }

    public void SetKnockBack(Vector2 value)
    {
        _knockBack = value;
    }
}
