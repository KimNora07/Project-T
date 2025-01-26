using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectT.Manager
{
    public class SceneController : MonoBehaviour
    {
        public void StartTouch()
        {
            StartCoroutine(TaptoStart());
        }
        private IEnumerator TaptoStart()
        {
            
            //Fade In/Out
            SceneManager.LoadScene("LobbyScene");
            GameManager.instance.isTitle = false;
            yield return null;
        }

        public void StartGameOnDoorPress()
        {
            StartCoroutine(StartGameCoroutine());
        }

        private IEnumerator StartGameCoroutine()
        {
            Debug.Log("½ÇÇà Áß");

            //Play Animation
            yield return new WaitForSeconds(2);
            //Fade In/Out
            SceneManager.LoadScene("MainGameScene");
            GameManager.instance.isInGame = true;

        }
    }
}

