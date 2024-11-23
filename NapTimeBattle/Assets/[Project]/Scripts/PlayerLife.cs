using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Color _hurtColor;
    [SerializeField] public float _maxLife = 100;
    [SerializeField] public float _currentLife = 0;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public bool _hisHide;

    private void Start()
    {
        _currentLife = _maxLife;
    }

    public void DoDamage(float value, Vector3 knockBack)
    {
        _currentLife -= value;
        StartCoroutine(InvincibilityDuration(1));
        if (_currentLife <= 0) Destroy(gameObject);
        _playerMovement.SetKnockBack(knockBack);
    }

    public IEnumerator InvincibilityDuration(float duration)
    {
        for (int i = 0; i < 4; i++)
        {
            _spriteRenderer.color = _hurtColor;
            yield return new WaitForSeconds(duration / 4 / 2);
            _spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(duration / 4 / 2);
        }
    }
}
