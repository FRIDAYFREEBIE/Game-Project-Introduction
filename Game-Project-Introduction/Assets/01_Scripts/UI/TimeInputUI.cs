using TMPro;
using UnityEngine;

public class TimeInputUI : MonoBehaviour
{
  [Header("타이머 정보")]
  public SO_TimerInfo timerInfo;

  [Header("시간 입력 필드")]
  public TMP_InputField inputField;

  [Header("씬 로드")]
  public SceneLoadUI sceneLoadUI;

  public void SubmitTime()
  {
    if(float.TryParse(inputField.text, out float timeValue)){
      timerInfo.time = timeValue;
      Debug.Log("설정된 타이머 시간: " + timeValue + "초");
      sceneLoadUI.OnClick();
    }
    else Debug.LogWarning("유효하지 않은 숫자 입력");
  }
}
