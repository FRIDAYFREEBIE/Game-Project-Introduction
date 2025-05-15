using UnityEngine;

public abstract class PlayerDetectorBase : MonoBehaviour
{
  [Header("단계 표시")]
  public bool isResearchStep = true;

  [Header("플레이어 탐지")]
  public LayerMask playerLayer;
  public Vector2 boxSize = new Vector2(1f, 1f);
  public Vector2 boxOffset = Vector2.zero;

  protected Collider2D player;

  protected virtual void Update()
  {
    if(PlayerMovement.IsClingingToWall){
      player = null;
      OnPlayerExit();
      return;
    }

    Vector2 boxCenter = (Vector2)transform.position + boxOffset;
    player = Physics2D.OverlapBox(boxCenter, boxSize, 0f, playerLayer);

    if(player != null) OnPlayerDetected();
    else OnPlayerExit();
  }

  protected abstract void OnPlayerDetected();
  protected abstract void OnPlayerExit();

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Vector2 boxCenter = (Vector2)transform.position + boxOffset;
    Gizmos.DrawWireCube(boxCenter, boxSize);
  }
}
