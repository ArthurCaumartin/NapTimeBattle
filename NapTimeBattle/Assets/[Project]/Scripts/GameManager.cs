using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public void Awake() { if (instance) Destroy(instance.gameObject); instance = this; }

    public PlayerLife _life1;
    public PlayerLife _life2;
    private float _deathTime;

    void Update()
    {
        if (_life1._currentLife <= 0 || _life2._currentLife <= 0)
        {
            _deathTime += Time.deltaTime;
            if (_deathTime >= 5)
            {
                if (_life1._currentLife <= 0 && _life2._currentLife <= 0)
                    SceneManager.LoadScene("NobodyWinScene");

                if (_life1._currentLife <= 0)
                    SceneManager.LoadScene("VictoryScenePlayer1");
                if (_life2._currentLife <= 0)
                    SceneManager.LoadScene("VictoryScenePlayer2");
            }
        }
    }
}


