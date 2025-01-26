using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjectT.Manager
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private Sprite openDoorSprite = null;
        [SerializeField] private Sprite closeDoorSprite = null;

        [SerializeField] private Image backgroundImage = null;

        private bool isOpenDoor = default;

        private void Start()
        {
            FadeManager.instance.FadeOut();
        }

        private void Update()
        {
            if(IsPointerOverUI())
            {
                backgroundImage.sprite = openDoorSprite;

            }
            else
            {
                if(!isOpenDoor)
                {
                    backgroundImage.sprite = closeDoorSprite;
                }
            }
        }

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
            isOpenDoor = true;
            FadeManager.instance.FadeIn(StartGameCoroutine);
        }

        private void StartGameCoroutine()
        {
            SceneManager.LoadScene("MainGameScene");
            GameManager.instance.isInGame = true;

        }

        private bool IsPointerOverUI()
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, results);

            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.layer == LayerMask.NameToLayer("Door"))
                    return true;
            }

            return false;
        }
    }
}

