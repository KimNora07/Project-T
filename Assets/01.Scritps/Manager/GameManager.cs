using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace ProjectT.Manager
{
    public class GameManager : MonoBehaviour
    {
        public int score;
        public TMP_Text scoreText;
        private float timer = 0f;
        public bool isInGame = false;
        public bool isTitle = false;

        [SerializeField] private GameObject optionPanel;

        public static GameManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);

                if (optionPanel != null)
                {
                    DontDestroyOnLoad(optionPanel);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            optionPanel.SetActive(false);
            isTitle = true;
        }

        private void Update()
        {
            if (isInGame)
            {
                timer += Time.deltaTime;

                if (timer >= 1f)
                {
                    score += 1;
                    timer -= 1f;
                    scoreText.text = score.ToString();
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape) && !isTitle)
            {
                if (optionPanel != null)
                {
                    optionPanel.SetActive(!optionPanel.activeSelf);
                }
            }
        }

        public void Continue()
        {
            if (optionPanel != null)
            {
                optionPanel.SetActive(!optionPanel.activeSelf);
            }
        }
        
        public void ExitGame()
        {
            if (isInGame)
            {
                SceneManager.LoadScene("LobbyScene");
                isInGame = false;
            }
            else
            {
                Debug.Log("Exit Game");
                Application.Quit();
            }
        }
    }
}
