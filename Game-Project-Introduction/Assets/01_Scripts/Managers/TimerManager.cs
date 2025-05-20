using UnityEngine;

public class TimerManager : MonoBehaviour
{
  public static TimerManager Instance { get; private set; }

  [Header("타이머")]
  public SO_TimerInfo timerInfo;
  public float timeOffset = 0f;

  public float currentTime = 0f;
  public bool canWork = true;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
      return;
    }
  }

  private void Start()
  {
    currentTime = 0f;
    Debug.Log(timerInfo.time);
  }

  private void Update()
  {
    if(canWork)
    {
      if(currentTime <= timerInfo.time) currentTime += Time.deltaTime;
      else GameManager.Instance.GameOver();
    }
  }

  public bool IsClear()
  {
    return currentTime >= timerInfo.time - timeOffset && currentTime <= timerInfo.time + timeOffset;
  }
}
