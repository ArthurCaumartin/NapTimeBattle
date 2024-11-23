using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerParry : MonoBehaviour
{
    public bool hisParry = false;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _parryCdDuration = 2;
    [SerializeField] private float _parryDuration;
    private bool _canParry = true;


    public void OnParry(InputValue value)
    {
        print(name + " / Parry");
        if (_canParry && value.Get<float>() > .5f)
        {
            hisParry = true;
            _canParry = false;
            StartCoroutine(CD());
            _animator.Play("Parry");
        }
    }

    public IEnumerator CD()
    {
        yield return new WaitForSeconds(_parryDuration);
        hisParry = false;
        yield return new WaitForSeconds(_parryCdDuration);
        _canParry = true;
    }
}