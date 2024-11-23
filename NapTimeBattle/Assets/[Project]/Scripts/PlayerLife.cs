using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Color _hurtColor;
    [SerializeField] private float _maxLife = 100;
    [SerializeField] public float _currentLife = 0;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public bool _hisHide;
    private bool _canBeHit = true;

    private void Start()
    {
        _currentLife = _maxLife;
    }

    public void DoDamage(float value, Vector3 knockBack)
    {
        if (_canBeHit)
        {

            _currentLife -= value;
            StartCoroutine(InvincibilityDuration(1));
            if (_currentLife <= 0) Destroy(gameObject);
            _playerMovement.SetKnockBack(knockBack);
        }
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
