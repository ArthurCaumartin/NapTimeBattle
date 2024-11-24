using System.Collections.Generic;
using UnityEngine;

public class Daroned : MonoBehaviour
{
    public static Daroned instance;
    private void Awake() { if (instance) Destroy(gameObject); instance = this; }

    [SerializeField] private List<PlayerLife> _playerLifeList;
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _animDoor;
    [SerializeField] private GameObject _animTv;
    [SerializeField] private GameObject _animWindow;
    [SerializeField] private float _minTimeBetweenDaronage = 10;
    [SerializeField] private float _maxTimeBetweenDaronage = 15;
    [Space]
    [SerializeField] private float _daronageDuration;
    private float _currentDaronageTime;
    private float _currentTimeBetweenDaronage;
    private bool _isDaronCheck;

    void Start()
    {
        _currentTimeBetweenDaronage = Random.Range(_minTimeBetweenDaronage, _maxTimeBetweenDaronage);
        DisableAnim();
    }

    public void Update()
    {
        if (_isDaronCheck == false)
        {
            _currentDaronageTime += Time.deltaTime;
            if (_currentDaronageTime > _currentTimeBetweenDaronage)
            {
                _currentDaronageTime = 0;
                DaronCheckAnimationOn();
                _isDaronCheck = true;
            }
        }
        else
        {
            foreach (var item in _playerLifeList)
            {
                if (!item._hisHide)
                {
                    item.DoDamage(1000, Vector2.zero, out bool notUse);
                    // enabled = false;
                }
            }

            _currentDaronageTime += Time.deltaTime;
            if (_currentDaronageTime > _daronageDuration)
            {
                _currentDaronageTime = 0;
                DisableAnim();
                _isDaronCheck = false;
            }
        }
    }

    public float GetRatio()
    {
        return Mathf.InverseLerp(0, _currentTimeBetweenDaronage, _currentDaronageTime);
    }

    private void DaronCheckAnimationOn()
    {
        AudioManager.instance.Play(AudioManager.instance.Daronage);
        int r = Random.Range(1, 4);
        if (r == 1)
        {
            _door.SetActive(true);
            _animDoor.SetActive(true);
        }
        if (r == 2) _animTv.SetActive(true);
        if (r == 3) _animWindow.SetActive(true);
    }

    public void DisableAnim()
    {
        _door.SetActive(false);
        _animDoor.SetActive(false);
        _animTv.SetActive(false);
        _animWindow.SetActive(false);
    }

    public void SetDarnedRatio(float value)
    {
        _currentDaronageTime = Mathf.Lerp(0, _currentTimeBetweenDaronage, value);
    }
}


