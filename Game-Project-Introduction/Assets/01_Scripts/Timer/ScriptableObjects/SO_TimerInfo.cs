using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTimerInfo", menuName = "Timer/Info")]
public class SO_TimerInfo : ScriptableObject
{
  public float time{get; set;}
}
