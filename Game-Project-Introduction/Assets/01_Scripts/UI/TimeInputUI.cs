using UnityEngine;
using TMPro;

public class TimeInputUI : MonoBehaviour
{
  public SO_TimerInfo timerInfo;
  public TMP_InputField inputField;
  public SceneLoadUI sceneLoadUI;

  public void SubmitTime()
  {
    string[] parts = inputField.text.Split(':');

    if (parts.Length == 2 &&
      int.TryParse(parts[0], out int hour) &&
      int.TryParse(parts[1], out int minute) &&
      hour >= 21 && hour <= 24 && (minute == 0 || minute == 30))
    {
      timerInfo.targetHour = hour;
      timerInfo.targetMinute = minute;

      Debug.Log($"목표 시간: {hour:D2}:{minute:D2}");
      sceneLoadUI.OnClick();
    }
  }
}
