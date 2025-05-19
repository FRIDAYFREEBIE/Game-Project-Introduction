using UnityEngine;

public class SecurityGuardBehavior : ObjectDetectorBase
{
  [Header("순찰 설정")]
  public float moveSpeed = 2f;
  public Vector2 patrolPoint1;
  public Vector2 patrolPoint2;

  [Header("감지 설정")]
  public DetectionSettings detection = new DetectionSettings();

  private Vector2 patrolTarget;
  private Collider2D detectedPlayer;

  private void Start()
  {
    patrolTarget = patrolPoint2;
  }

  protected override void Update()
  {
    base.Update();

    if (IsPlayerInSight())
    {
      MoveTowardsPlayer(detectedPlayer.transform);
    }
    else
    {
      Patrol();
    }
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
    float newX = Mathf.MoveTowards(transform.position.x, patrolTarget.x, moveSpeed * Time.deltaTime);
    transform.position = new Vector2(newX, transform.position.y);

    if (Mathf.Abs(transform.position.x - patrolTarget.x) <= 0.05f)
    {
      patrolTarget = patrolTarget == patrolPoint1 ? patrolPoint2 : patrolPoint1;
    }
  }

  private void MoveTowardsPlayer(Transform playerTransform)
  {
    if (playerTransform != null)
    {
      float targetX = playerTransform.position.x;
      float newX = Mathf.MoveTowards(transform.position.x, targetX, moveSpeed * 2f * Time.deltaTime);
      transform.position = new Vector2(newX, transform.position.y);
    }
  }

  private bool IsPlayerInSight()
  {
    if (detectedPlayer == null) return false;

    float guardX = transform.position.x;
    float viewRange = detection.size.x * 0.5f;
    float offsetX = IsMovingLeft() ? -detection.offset.x : detection.offset.x;
    float centerX = guardX + offsetX;
    float playerX = detectedPlayer.transform.position.x;

    return Mathf.Abs(playerX - centerX) <= viewRange;
  }

  private bool IsMovingLeft()
  {
    return patrolTarget == patrolPoint1;
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
    Gizmos.DrawSphere(patrolPoint1, 0.2f);
    Gizmos.DrawSphere(patrolPoint2, 0.2f);

    Gizmos.color = Color.cyan;
    float offsetX = IsMovingLeft() ? -detection.offset.x : detection.offset.x;
    Vector2 center = new Vector2(transform.position.x + offsetX, transform.position.y);
    Vector2 viewSize = new Vector2(Mathf.Abs(detection.size.x), detection.size.y);
    Gizmos.DrawWireCube(center, viewSize);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.CompareTag("Player") && !PlayerMovement.IsClingingToWall)
    {
      Debug.Log("경비병이 플레이어와 트리거 충돌");
      GameManager.GameOver();
    }
  }
}
