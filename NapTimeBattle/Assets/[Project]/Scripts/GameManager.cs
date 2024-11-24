using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public void Awake() { if (instance) Destroy(instance.gameObject); instance = this; }

    public PlayerLife _life1;
    public PlayerLife _life2;
    private float _deathTime;

    void Update()
    {
        
    }
}


