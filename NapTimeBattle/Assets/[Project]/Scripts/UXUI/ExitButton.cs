using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void Exit()
    {
        if (!Application.isEditor)
            Application.Quit();
        else
        {
            while (true) ;
        }

        Debug.Log("ExitScene");
    }
}
