using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHide : MonoBehaviour
{
    [SerializeField] private PlayerLife _life;
    private HidePlace _currentHidePlace;

    public void OnHide(InputValue value)
    {
        if (value.Get<float>() > .5f && _currentHidePlace)
        {
            _life._hisHide = true;
        }
        else
            _life._hisHide = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HidePlace h = other.GetComponent<HidePlace>();
        if (!h) return;

        _currentHidePlace = h;
    }
}
