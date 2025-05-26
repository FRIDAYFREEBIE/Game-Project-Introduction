using UnityEngine;

[CreateAssetMenu(fileName = "NewTimerInfo", menuName = "Timer/Info")]
public class SO_TimerInfo : ScriptableObject
{
  public int startHour;
  public int startMinute;
  public int targetHour;
  public int targetMinute;
}
