using UnityEngine;

public class PlayerEscape : PlayerDetectorBase
{
  public SO_SelectedPath selectedPath;

  protected override void OnDetected(Collider2D[] targets)
  {
    foreach(var target in targets)
    {
      var detected = target.GetComponent<DectectedObjectBase>();
      if(detected != null)
      {
        if (GameManager.ReturnGetTarget() &&
           TimerManager.Instance.IsClear() &&
           detected.objectID == selectedPath.escapeId)
        {
          GameManager.Instance.GameClear();
          Debug.Log($"탈출 성공: {detected.objectID}");
        }
        else
        {
          Debug.Log($"탈출 조건 불일치: {detected.objectID} ≠ {selectedPath.escapeId}");
          Debug.Log($"타임매니저: {TimerManager.Instance.IsClear()}");
          Debug.Log($"게임매니저: {GameManager.ReturnGetTarget()}");
        }
      }
    }
  }
}
