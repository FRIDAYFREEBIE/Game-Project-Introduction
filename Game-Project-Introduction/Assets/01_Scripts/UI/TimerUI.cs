using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
  [Header("타이머")]
  public TimerManager timerManager;
  public TextMeshProUGUI textMeshPro;

  private void Update()
  {
    int temp = (int)timerManager.currentTime;
    textMeshPro.text = temp.ToString();
  }
}
