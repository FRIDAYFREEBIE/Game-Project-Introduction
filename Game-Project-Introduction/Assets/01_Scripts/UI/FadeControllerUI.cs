using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeControllerUI : MonoBehaviour
{
  public static FadeControllerUI Instance { get; private set; }

  public Image fadeImage;
  public float fadeDuration = 0.5f;

  private void Awake()
  {
    if(Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
      return;
    }

    FadeIn();
  }

  public void FadeIn()
  {
    StartCoroutine(Fade(1f, 0f));
  }

  public void FadeOut()
  {
    StartCoroutine(Fade(0f, 1f));
  }

  private IEnumerator Fade(float from, float to)
  {
    float time = 0f;
    Color c = fadeImage.color;

    while (time < fadeDuration)
    {
      time += Time.deltaTime;
      float t = Mathf.Clamp01(time / fadeDuration);
      c.a = Mathf.Lerp(from, to, t);
      fadeImage.color = c;
      yield return null;
    }

    c.a = to;
    fadeImage.color = c;
  }
}
