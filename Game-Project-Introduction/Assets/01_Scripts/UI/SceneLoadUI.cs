using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadUI : MonoBehaviour
{
  [Header("로드 할 씬")]
  public string loadSceneName = "";

  public void OnClick()
  {
    SceneManager.LoadScene(loadSceneName);
  }
}
