using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    public GameObject canva;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Jeu en pause");
        canva.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Jeu repris");
    }
}