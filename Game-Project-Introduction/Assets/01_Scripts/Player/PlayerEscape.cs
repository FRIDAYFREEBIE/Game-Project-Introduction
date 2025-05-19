using UnityEngine;

public class PlayerEscape : PlayerDetectorBase
{
  public TimerManager timerManager;
  public SO_SelectedPath selectedPath;

  protected override void OnDetected(Collider2D[] targets)
  {
    foreach(var target in targets)
    {
      var detected = target.GetComponent<DectectedObjectBase>();
      if(detected != null)
      {
        if(GameManager.ReturnGetTarget() &&
           timerManager.isClear() &&
           detected.objectID == selectedPath.escapeId)
        {
          GameManager.GameClear();
          Debug.Log($"탈출 성공: {detected.objectID}");
        }
        else
        {
          Debug.Log($"탈출 조건 불일치: {detected.objectID} ≠ {selectedPath.escapeId}");
        }
      }
    }
  }
}
