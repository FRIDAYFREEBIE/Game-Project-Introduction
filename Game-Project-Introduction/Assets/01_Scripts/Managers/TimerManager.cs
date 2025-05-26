using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
  public static TimerManager Instance { get; private set; }

  public SO_TimerInfo timerInfo;
  public float timeOffset = 0f;

  public int currentHour;
  public int currentMinute;
  private float timer = 0f;
  public bool canWork = true;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      SceneManager.sceneLoaded += OnSceneLoaded;
    }
    else
    {
      Destroy(gameObject);
      return;
    }

    DontDestroyOnLoad(gameObject);
  }

  private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
  {
    InitializeTimer();
  }

  private void InitializeTimer()
  {
    currentHour = 0;
    currentMinute = 0;
    Debug.Log("타이머 초기화 완료");
  }

  private void Start()
  {
    currentHour = timerInfo.startHour;
    currentMinute = timerInfo.startMinute;
  }

  private void Update()
  {
    if (!canWork) return;

    timer += Time.deltaTime;

    if (timer >= 1f)
    {
      timer = 0f;
      currentMinute++;

      if (currentMinute >= 60)
      {
        currentMinute = 0;
        currentHour++;
      }

      if (HasReachedTargetTime())
      {
        GameManager.Instance.GameOver();
      }
    }
  }

  public bool IsClear()
  {
    int currentTotalMinutes = currentHour * 60 + currentMinute;
    int targetTotalMinutes = timerInfo.targetHour * 60 + timerInfo.targetMinute;

    return Mathf.Abs(currentTotalMinutes - targetTotalMinutes) <= timeOffset;
  }

  private bool HasReachedTargetTime()
  {
    return currentHour > timerInfo.targetHour ||
          (currentHour == timerInfo.targetHour && currentMinute >= timerInfo.targetMinute);
  }
}
