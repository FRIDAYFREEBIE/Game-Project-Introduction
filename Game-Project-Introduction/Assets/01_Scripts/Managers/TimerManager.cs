using System.Threading;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
  [Header("타이머")]
  public SO_TimerInfo timerInfo;
  public float timeOffset = 0f;

  [HideInInspector]
  public float currentTime = 0f;

  private void Start()
  {
    timerInfo.time = 15f;
    currentTime = 0f;
  }

  private void Update()
  {
    if(currentTime <= timerInfo.time) currentTime += Time.deltaTime;
    else Debug.Log("클리어 실패");
  }

  // 성공
  public bool isClear()
  {
    if(currentTime <= timerInfo.time + timeOffset && currentTime >= timerInfo.time - timeOffset) return true;
    else return false;
  }
}
