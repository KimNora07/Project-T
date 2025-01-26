using System.Collections;
using TMPro;
using UnityEngine;

public class TextFadeEffect : MonoBehaviour
{
    public TextMeshProUGUI text; // 페이드 효과를 적용할 TextMeshProUGUI
    public float fadeDuration = 1.0f; // 페이드 효과의 지속 시간
    public float delayBetweenFades = 0.5f; // 페이드 인/아웃 사이의 지연 시간
    private bool isFading = true;

    private void Start()
    {
        // 사라졌다 나타나는 효과 시작
        StartCoroutine(FadeInOutLoop());
    }

    private IEnumerator FadeInOutLoop()
    {
        while (isFading)
        {
            // 페이드 아웃
            yield return FadeOutText();
            yield return new WaitForSeconds(delayBetweenFades);

            // 페이드 인
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
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration); // 알파 값 감소
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // 완전히 투명
    }

    public IEnumerator FadeInText()
    {
        float elapsedTime = 0f;
        Color originalColor = text.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration); // 알파 값 증가
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // 완전히 불투명
    }
}
