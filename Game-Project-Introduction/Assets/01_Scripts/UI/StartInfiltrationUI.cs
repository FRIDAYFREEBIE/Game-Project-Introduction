using UnityEngine;
using UnityEngine.SceneManagement;

public class StartInfiltrationUI : MonoBehaviour
{
  public void OnClick()
  {
    SceneManager.LoadScene("InfiltrationScene");
  }
}
