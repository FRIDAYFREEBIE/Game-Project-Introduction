using UnityEngine;

public abstract class PlayerDetectorBase : MonoBehaviour
{
  [Header("공통 탐지 설정")]
  public LayerMask detectionLayer;
  public Vector2 boxSize = new Vector2(1f, 1f);
  public KeyCode activationKey = KeyCode.F;

  protected virtual void Update()
  {
    if(Input.GetKeyDown(activationKey))
    {
      Vector2 boxCenter = (Vector2)transform.position;
      Collider2D[] results = Detector.DetectAll(boxCenter, boxSize, detectionLayer);
      OnDetected(results);
    }
  }

  protected abstract void OnDetected(Collider2D[] targets);

  protected virtual void OnDrawGizmos()
  {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireCube((Vector2)transform.position, boxSize);
  }
}
