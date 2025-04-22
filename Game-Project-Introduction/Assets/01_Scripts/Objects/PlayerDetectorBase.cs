using UnityEngine;

public abstract class PlayerDetectorBase : MonoBehaviour
{
  [Header("플레이어 탐지")]
  public LayerMask playerLayer;
  public Vector2 boxSize = new Vector2(1f, 1f);
  public Vector2 boxOffset = Vector2.zero;

  protected Collider2D player;

  protected virtual void Update()
  {
    Vector2 boxCenter = (Vector2)transform.position + boxOffset;
    player = Physics2D.OverlapBox(boxCenter, boxSize, 0f, playerLayer);

    if(player != null) OnPlayerDetected();
    else OnPlayerExit();
  }

  // 플레이어 감지
  protected abstract void OnPlayerDetected();

  // 플레이어 감지 헤제
  protected abstract void OnPlayerExit();

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Vector2 boxCenter = (Vector2)transform.position + boxOffset;
    Gizmos.DrawWireCube(boxCenter, boxSize);
  }
}
