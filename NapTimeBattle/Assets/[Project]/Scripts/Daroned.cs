using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Daroned : MonoBehaviour
{
    public static Daroned instance;
    private void Awake() { if (instance) Destroy(gameObject); instance = this; 
    }
    [SerializeField] private List<PlayerLife> _playerLifeList;
    [SerializeField] private float _minTimeBetweenDaronage = 10;
    [SerializeField] private float _maxTimeBetweenDaronage = 15;
    public float _currentDaronageTime;
    public float _currentTimeBetweenDaronage;

    void Start()
    {
        _currentTimeBetweenDaronage = Random.Range(_minTimeBetweenDaronage, _maxTimeBetweenDaronage);
    }


    public void Update()
    {
        _currentDaronageTime += Time.deltaTime;
        if (_currentDaronageTime > _currentTimeBetweenDaronage)
        {
            _currentDaronageTime = 0;
            DaronCheck();
        }
    }

    private void DaronCheck()
    {
        foreach (var item in _playerLifeList)
        {
            if (!item._hisHide) item.DoDamage(1000, Vector2.zero, out bool notUse);
        }
        enabled = false;
    }

    public void SetDarnedRatio(float value)
    {
        _currentDaronageTime = Mathf.Lerp(0, _currentTimeBetweenDaronage, value);
    }
}


