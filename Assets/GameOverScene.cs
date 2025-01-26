using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    private void Start()
    {
        FadeManager.instance.FadeOut();
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            FadeManager.instance.FadeIn(
                () =>
                {
                    SceneManager.LoadScene("LobbyScene");
                }
                );
        }
    }
}
