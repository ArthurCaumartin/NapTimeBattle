using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFill;
    [SerializeField] private PlayerLife _playerLife; 

    private void Update()
    {
        if (_playerLife != null && _healthBarFill != null)
        {
            float healthPercentage = Mathf.Clamp01(_playerLife._currentLife / _playerLife._maxLife);
            _healthBarFill.fillAmount = healthPercentage;
        }
    }
}