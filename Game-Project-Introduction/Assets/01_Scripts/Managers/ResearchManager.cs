using UnityEngine;
using UnityEngine.SceneManagement;

public class ResearchManager : MonoBehaviour
{
  [Header("이동할 씬 이름")]
  public string sceneName;

  void OnTriggerEnter2D(Collider2D other)
  {
    if(other.CompareTag("Player")) SceneManager.LoadScene(sceneName);
  }
}
