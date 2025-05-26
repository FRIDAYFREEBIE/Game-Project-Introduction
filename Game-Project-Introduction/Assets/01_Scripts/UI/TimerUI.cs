using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
  public TextMeshProUGUI textMeshPro;

  private void Update()
  {
    textMeshPro.text = $"{TimerManager.Instance.currentHour:D2}:{TimerManager.Instance.currentMinute:D2}";
  }
}
