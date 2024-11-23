using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public void Awake() { if (instance) Destroy(instance.gameObject); instance = this; }



}


