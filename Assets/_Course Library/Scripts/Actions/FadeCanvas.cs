using System.Collections;
using UnityEngine;

/// <summary>
/// Fades a canvas over time using a coroutine and a canvas group
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
public class FadeCanvas : MonoBehaviour
{
    [Tooltip("The speed at which the canvas fades")]
    public float defaultDuration = 1.0f;

    public Coroutine CurrentRoutine { private set; get; } = null;

    private CanvasGroup canvasGroup = null;
    private float alpha = 0.0f;

    private float quickFadeDuration = 0.25f;
    public float wakeUP;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        StartFadeOut();
    }

    public void StartFadeIn()
    {
        StopAllCoroutines();
        CurrentRoutine = StartCoroutine(FadeIn(defaultDuration));
    }

    public void StartFadeOut()
    {
        StopAllCoroutines();
        CurrentRoutine = StartCoroutine(FadeOut(defaultDuration));
    }

    public void StartSlowlyFadeOut()
    {
        StopAllCoroutines();
        CurrentRoutine = StartCoroutine(SlowlyFadeOut(wakeUP, 1));
    }

    public void QuickFadeIn()
    {
        StopAllCoroutines();
        CurrentRoutine = StartCoroutine(FadeIn(quickFadeDuration));
    }

    public void QuickFadeOut()
    {
        StopAllCoroutines();
        CurrentRoutine = StartCoroutine(FadeOut(quickFadeDuration));
    }

    private IEnumerator FadeIn(float duration)
    {
        float elapsedTime = 0.0f;

        while (alpha <= 1.0f)
        {
            SetAlpha(elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator FadeOut(float duration)
    {
        float elapsedTime = 0.0f;

        while (alpha >= 0.0f)
        {
            SetAlpha(1 - (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator SlowlyFadeOut(float slowDuration, float fastDuration)
    {
        float elapsedTime = 0.0f;

        // İlk olarak alpha'yı 0.9 ile 1 arasında yavaşça azalt.
        while (elapsedTime < slowDuration)
        {
            float alpha = Mathf.SmoothStep(1.0f, 0.9f, elapsedTime / slowDuration);
            SetAlpha(alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Daha sonra alpha'yı 0.9'dan 0'a hızla azalt.
        elapsedTime = 0.0f; // Zamanı sıfırla
        while (elapsedTime < fastDuration)
        {
            float alpha = Mathf.SmoothStep(0.9f, 0.0f, elapsedTime / fastDuration);
            SetAlpha(alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Son olarak alpha tamamen sıfırlanmış olmalı
        SetAlpha(0.0f);
    }



    private void SetAlpha(float value)
    {
        alpha = value;
        canvasGroup.alpha = alpha;
    }

}