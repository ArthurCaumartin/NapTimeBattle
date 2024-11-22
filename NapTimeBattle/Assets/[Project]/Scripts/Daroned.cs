using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Daroned : MonoBehaviour
{
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
        if(_currentDaronageTime > _currentTimeBetweenDaronage)
        {
            _currentDaronageTime = 0;
            DaronCheck();
        }
    }

    private void DaronCheck()
    {
        foreach (var item in _playerLifeList)
        {
            if(!item._hisHide) item.DoDamage(1000, Vector2.zero);
        }
        enabled = false;
    }
}


