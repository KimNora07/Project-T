using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Let's go");
        SceneManager.LoadScene("");
    }
    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
