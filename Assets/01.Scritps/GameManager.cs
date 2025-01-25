using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    private float timer = 0f;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)           
        {
            score += 1;            
            timer -= 1f;
            scoreText.text = score.ToString();
        }
    }

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
