using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Attack _attack;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _attackPerSecond = 1;
    private float _attackTime;
    private bool _hasAttack = false;

    private void Update()
    {
        _attackTime += Time.deltaTime;
        if (_attackTime > 1 / _attackPerSecond && _hasAttack)
        {
            _attackTime = 0;
            Attack();
        }
        _hasAttack = false;
    }

    private void OnAttack(InputValue value)
    {
        _hasAttack = true;
    }

    private void Attack()
    {
        _animator.SetTrigger("AttackTrigger");
    }
}
