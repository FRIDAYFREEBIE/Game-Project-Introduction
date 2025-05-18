using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static bool isGetTarget = false;

  [Header("경로")]
  public Transform player;
  public SO_SelectedPath selectedPath;
  public Transform path1;
  public Transform path2;

  void Awake()
  {
    if(selectedPath.entryId == 0) player.transform.position = path1.transform.position;
    else player.transform.position = path2.transform.position;
  }

  public static void GameClear()
  {
    Debug.Log("게임클리어");
    SceneManager.LoadScene("ClearScene");
  }

  public static void GameOver()
  {
    Debug.Log("게임오버");
    SceneManager.LoadScene("PlanTableScene");
  }

  public static void GetTarget()
  {
    isGetTarget = true;
  }

  public static bool ReturnGetTarget()
  {
    return isGetTarget;
  }
}
