using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance{get; private set;}

  public static bool isGetTarget = false;

  [Header("경로")]
  public Transform player;
  public SO_SelectedPath selectedPath;
  public Transform path1;
  public Transform path2;

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

    if (selectedPath.entryId == 0)
    {
      Vector3 pos = path1.transform.position;
      pos.y -= 1f;
      player.position = pos;
    }
    else
    {
      Vector3 pos = path2.transform.position;
      pos.y -= 1f;
      player.position = pos;
    }
  }

  public void GameClear()
  {
    Debug.Log("게임클리어");
    StartCoroutine(LoadSceneWithFade("ClearScene"));
  }

  public void GameOver()
  {
    Debug.Log("게임오버");
    StartCoroutine(LoadSceneWithFade("PlanTableScene"));
  }

  public static void GetTarget()
  {
    isGetTarget = true;
  }

  public static bool ReturnGetTarget()
  {
    return isGetTarget;
  }

  private IEnumerator LoadSceneWithFade(string loadSceneName)
  {
    FadeControllerUI.Instance.FadeOut();
    yield return new WaitForSeconds(FadeControllerUI.Instance.fadeDuration + 0.5f);
    SceneManager.LoadScene(loadSceneName);
    TimerManager.Instance.canWork = false;
  }
}