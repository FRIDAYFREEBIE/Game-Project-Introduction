using UnityEngine;

public class ExitGameUI : MonoBehaviour
{
  public void ExitGame()
  {
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;

    #else
    Application.Quit();
    
    #endif
  }
}
