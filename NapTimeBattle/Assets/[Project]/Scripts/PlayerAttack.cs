using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _attackPerSecond = 1;
    private float _attackTime;

    private void Update()
    {
        _animator.SetFloat("AttackSpeed", 1 / _attackPerSecond);
        _attackTime += Time.deltaTime;
        if (_attackTime > 1 / _attackPerSecond)
        {
            _attackTime = 0;
            Attack();
        }
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}
