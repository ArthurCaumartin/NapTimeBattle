using UnityEngine;

public class AnimatorControler : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public static string IDLE = "Idle";
    public static string MOVE_RIGHT = "MoveRight";
    public static string MOVE_LEFT = "MoveLeft";

    public string _currentState;

    public void SetState(string toSet)
    {   
        if(_currentState == toSet) return;
        _currentState = toSet;
        _animator.Play(_currentState);
    }
}
