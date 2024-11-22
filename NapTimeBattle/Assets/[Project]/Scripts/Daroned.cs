using UnityEngine;

public class Daroned : MonoBehaviour
{
    [SerializeField] private float _minTimeBetweenDaronage = 10;
    [SerializeField] private float _maxTimeBetweenDaronage = 15;
    private float _currentDaronageTime;
    private float _currentTimeBetweenDaronage;

    void Start()
    {
        _currentTimeBetweenDaronage = Random.Range(_minTimeBetweenDaronage, _maxTimeBetweenDaronage);
    }


    public void Update()
    {
        _currentDaronageTime += Time.deltaTime;
        if(_currentDaronageTime > _currentTimeBetweenDaronage)
        {
            
        }
    }
}


