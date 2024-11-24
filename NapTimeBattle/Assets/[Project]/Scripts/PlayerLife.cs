using System;
using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Color _hurtColor;
    [SerializeField] public float _maxLife = 100;
    [SerializeField] public float _currentLife = 0;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerParry _playerParry;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public bool _hisHide;
    private bool _canBeHit = true;

    private void Start()
    {
        _currentLife = _maxLife;
    }

    public void DoDamage(float damageValue, Vector3 knockBack, out bool hisParry)
    {
        hisParry = _playerParry.hisParry;

        if(GetComponent<Pyjama>()) damageValue *= .5f;

        if (_canBeHit && !_playerParry.hisParry)
        {
            _currentLife -= damageValue;
            StartCoroutine(InvincibilityDuration(1));
            _playerMovement.SetKnockBack(knockBack);

            if (_currentLife <= 0)
            {
                _playerMovement.enabled = false;
                _playerAttack.enabled = false;
                _animator.Play("Death");
            }
        }
    }

    public void Heal(float healValue)
    {
        _currentLife += healValue;
        if(_currentLife > _maxLife) _currentLife = _maxLife;
    }

    public IEnumerator InvincibilityDuration(float duration)
    {
        _canBeHit = false;
        for (int i = 0; i < 4; i++)
        {
            _spriteRenderer.color = _hurtColor;
            yield return new WaitForSeconds(duration / 4 / 2);
            _spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(duration / 4 / 2);
        }
        _canBeHit = true;
    }
}
