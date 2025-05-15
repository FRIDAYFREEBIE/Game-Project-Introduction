using UnityEngine;

public class PlayerGetTarget : MonoBehaviour
{
  [Header("목표 탐지")]
  public LayerMask clueLayer;
  public Vector2 boxSize = new Vector2(1f, 1f);

  private void Update()
  {
    // 목표물 수집
    if(Input.GetKeyDown(KeyCode.F)){
      Vector2 boxCenter = (Vector2)transform.position;
      Collider2D target = Detector.Detect(boxCenter, boxSize, clueLayer);

      if(target != null) GameManager.GetTarget();
    }
  }
}