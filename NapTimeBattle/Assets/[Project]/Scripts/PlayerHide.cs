using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHide : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private Sprite _bedHideSprite;
    [SerializeField] private PlayerLife _life;
    private HidePlace _currentHidePlace;
    private InputAction _hideAction;

    void Start()
    {
        _hideAction = GetComponent<PlayerInput>().actions.FindAction("Hide");
    }

    // public void OnHide(InputValue value)
    // {
    //     if (value.Get<float>() > .5f && _currentHidePlace)
    //     {
    //         _life._hisHide = true;
    //     }
    //     else
    //         _life._hisHide = false;
    // }

    void Update()
    {
        if (_currentHidePlace && _currentHidePlace.isAuto)
        {
            _life._hisHide = true;
        }
        else
        {
            if (_currentHidePlace is HideBed && _life._currentLife > 0)
            {
                _life._hisHide = _hideAction.ReadValue<float>() > .5f && _currentHidePlace;
                ((HideBed)_currentHidePlace).SetSprite(_hideAction.ReadValue<float>() > .5f ? _bedHideSprite : null);
                _playerSprite.enabled = !(_hideAction.ReadValue<float>() > .5f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HidePlace h = other.GetComponent<HidePlace>();
        if (!h) return;

        _currentHidePlace = h;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        HidePlace h = other.GetComponent<HidePlace>();
        if (!h) return;

        HideBed hb = h as HideBed;
        hb?.SetSprite(null);

        _currentHidePlace = null;
    }
}
