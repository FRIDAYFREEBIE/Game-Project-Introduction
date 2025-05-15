using UnityEngine;

public class SecurityGuardBehavior : PlayerDetectorBase
{
  [Header("적 이동")]
  public float moveSpeed = 2f;
  public Vector2 patrolPoint1;
  public Vector2 patrolPoint2;
  private Vector2 patrolTarget;

  [Header("시야 설정")]
  public Vector2 viewSize = new Vector2(3f, 1f);  // 박스 크기
  public Vector2 viewOffset = new Vector2(2.24f, 0f);  // 박스 오프셋

  private Collider2D detectedPlayer;

  private void Start()
  {
    patrolTarget = patrolPoint2;
  }

  protected override void Update()
  {
    base.Update();

    if (IsPlayerInSight()) MoveTowardsPlayer(detectedPlayer.transform);
    else Patrol();
  }

  protected override void OnPlayerDetected()
  {
    detectedPlayer = player;
  }

  protected override void OnPlayerExit()
  {
    detectedPlayer = null;
  }

  private void Patrol()
  {
    transform.position = Vector2.MoveTowards(transform.position, patrolTarget, moveSpeed * Time.deltaTime);

    if ((Vector2)transform.position == patrolTarget)
    {
      patrolTarget = patrolTarget == patrolPoint1 ? patrolPoint2 : patrolPoint1;
    }
  }

  private void MoveTowardsPlayer(Transform playerTransform)
  {
    if (playerTransform != null) transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * 2 * Time.deltaTime);
  }

  private bool IsPlayerInSight()
  {
    if (detectedPlayer == null) return false;

    Vector2 boxCenter = (Vector2)transform.position + viewOffset;

    if(IsMovingLeft())
    {
      boxCenter = (Vector2)transform.position - viewOffset;
      viewSize.x = -viewSize.x;
    }

    Collider2D playerCollider = Physics2D.OverlapBox(boxCenter, viewSize, 0f);

    return playerCollider != null;
  }

  private bool IsMovingLeft()
  {
    return patrolTarget == patrolPoint1;
  }

  void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
    Gizmos.DrawSphere(patrolPoint1, 0.2f);
    Gizmos.DrawSphere(patrolPoint2, 0.2f);

    Gizmos.color = Color.cyan;
    Vector2 boxCenter = (Vector2)transform.position + viewOffset;

    if(IsMovingLeft())
    {
      boxCenter = (Vector2)transform.position - viewOffset;
      Gizmos.DrawWireCube(boxCenter, new Vector2(-viewSize.x, viewSize.y));
    }
    else
    {
      Gizmos.DrawWireCube(boxCenter, viewSize);
    }
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if(other.collider.CompareTag("Player")) GameManager.GameOver();
  }
}