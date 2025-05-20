using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoadUI : MonoBehaviour
{
  [Header("로드 할 씬")]
  public string loadSceneName = "";

  public void OnClick()
  {
    StartCoroutine(LoadSceneWithFade());
  }

  private IEnumerator LoadSceneWithFade()
  {
    FadeControllerUI.Instance.FadeOut();
    yield return new WaitForSeconds(FadeControllerUI.Instance.fadeDuration);
    SceneManager.LoadScene(loadSceneName);
  }
}
