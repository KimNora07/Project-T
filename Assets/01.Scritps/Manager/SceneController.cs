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

        private void OnEnable()
        {
            FadeManager.instance.FadeOut();

        }

        private void Update()
        {
            if(backgroundImage == null || closeDoorSprite == null || openDoorSprite == null)
            {
                return;
            }

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
            FadeManager.instance.FadeIn(TaptoStart);
        }
        private void TaptoStart()
        {
            SceneManager.LoadScene("LobbyScene");
            GameManager.instance.isTitle = false;
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

