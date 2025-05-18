using UnityEngine;

public class PlayerEscape : MonoBehaviour
{
  [Header("목표 탐지")]
  public LayerMask escapeLayer;
  public Vector2 boxSize = new Vector2(1f, 1f);
  public TimerManager timerManager;
  public SO_SelectedPath selectedPath;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.F))
    {
      Vector2 boxCenter = (Vector2)transform.position;
      Collider2D target = Detector.Detect(boxCenter, boxSize, escapeLayer);

      if(target != null){
        DectectedObjectBase dectectedObjectBase = target.GetComponent<DectectedObjectBase>();
        if(GameManager.ReturnGetTarget() && timerManager.isClear() && dectectedObjectBase.objectID == selectedPath.escapeId) GameManager.GameClear();
        Debug.Log(dectectedObjectBase.objectID);
        Debug.Log(selectedPath.escapeId);
      }

    }
  }

  void OnDrawGizmos()
  {
    Gizmos.color = Color.yellow;

    // 박스 중앙은 플레이어의 현재 위치
    Vector2 boxCenter = (Vector2)transform.position;

    // 박스 사이즈 및 위치로 WireCube 그리기
    Gizmos.DrawWireCube(boxCenter, boxSize);
  }
}
