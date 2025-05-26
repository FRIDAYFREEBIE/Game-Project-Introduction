using UnityEngine;
using TMPro;

public class StartTimeSelector : MonoBehaviour
{
  [Header("타이머 정보")]
  public SO_TimerInfo timerInfo;

  [Header("시작 시간 표시")]
  public TextMeshProUGUI startTimeText;

  private int hour = 21;
  private int minute = 0;

    private void Start()
    {
        startTimeText.text = "21:00";
        timerInfo.startHour = hour;
        timerInfo.startMinute = minute;
  }

  public void IncreaseStartTime()
    {
        minute += 30;
        if (minute >= 60)
        {
            minute = 0;
            hour++;
        }

        if (hour >= 24)
        {
            hour = 21;
            minute = 0;
        }

        timerInfo.startHour = hour;
        timerInfo.startMinute = minute;

        UpdateDisplay();
    }

  private void UpdateDisplay()
  {
    startTimeText.text = $"{hour:D2}:{minute:D2}";
  }
}
