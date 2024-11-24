using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public string nameScene;
   public void LoadScene()
   {
    SceneManager.LoadScene(nameScene);
   }

}
