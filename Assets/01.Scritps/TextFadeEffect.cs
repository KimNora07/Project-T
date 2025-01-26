using System.Collections;
using TMPro;
using UnityEngine;

public class TextFadeEffect : MonoBehaviour
{
    public TextMeshProUGUI text; // ���̵� ȿ���� ������ TextMeshProUGUI
    public float fadeDuration = 1.0f; // ���̵� ȿ���� ���� �ð�
    public float delayBetweenFades = 0.5f; // ���̵� ��/�ƿ� ������ ���� �ð�
    private bool isFading = true;

    private void Start()
    {
        // ������� ��Ÿ���� ȿ�� ����
        StartCoroutine(FadeInOutLoop());
    }

    private IEnumerator FadeInOutLoop()
    {
        while (isFading)
        {
            // ���̵� �ƿ�
            yield return FadeOutText();
            yield return new WaitForSeconds(delayBetweenFades);

            // ���̵� ��
            yield return FadeInText();
            yield return new WaitForSeconds(delayBetweenFades);
        }
    }

    public IEnumerator FadeOutText()
    {
        float elapsedTime = 0f;
        Color originalColor = text.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration); // ���� �� ����
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // ������ ����
    }

    public IEnumerator FadeInText()
    {
        float elapsedTime = 0f;
        Color originalColor = text.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration); // ���� �� ����
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // ������ ������
    }
}
