using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float _maxLife = 100;
    [SerializeField] private float _currentLife = 0;

    private void Start()
    {
        _currentLife = _maxLife;
    }

    public void DoDamage(float value)
    {
        _currentLife -= value;
    }
}
