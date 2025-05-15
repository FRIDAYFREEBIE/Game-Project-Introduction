using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static bool isGetTarget = false;

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
