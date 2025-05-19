using UnityEngine;

public class CCTVBehavior : ObjectDetectorBase
{
  public float rotationSpeed = 30f;
  public float waitTimeAtAngle = 1f;
  private float currentAngle = 0f;
  public bool isWaiting = false;
  private float waitTimer = 0f;

  public Vector2 viewSize = new Vector2(3f, 1f);
  public Vector2 viewOffset = new Vector2(2.24f, 0f);

  private bool rotatingToPositive = true;
  private Collider2D detectedPlayer;
  public float playerDetectionTimer = 0f;

  protected override void Update()
  {
    base.Update();

    if(!isWaiting) Rotate();
    else
    {
      waitTimer += Time.deltaTime;
      if(waitTimer >= waitTimeAtAngle) isWaiting = false;
    }

    // 플레이어 감지 상태 체크
    if(detectedPlayer != null) 
    {
      playerDetectionTimer += Time.deltaTime;
      if(playerDetectionTimer >= 2f) OnPlayerDetected();
    }
    else playerDetectionTimer = 0f;
  }

  private void Rotate()
  {
    if (rotatingToPositive) currentAngle += rotationSpeed * Time.deltaTime;
    else currentAngle -= rotationSpeed * Time.deltaTime;

    if(currentAngle >= 45f && rotatingToPositive)
    {
      currentAngle = 45f;
      isWaiting = true;
      waitTimer = 0f;
      rotatingToPositive = false;
    }
    else if(currentAngle <= -45f && !rotatingToPositive)
    {
      currentAngle = -45f;
      isWaiting = true;
      waitTimer = 0f;
      rotatingToPositive = true;
    }

    transform.rotation = Quaternion.Euler(0, 0, currentAngle);
  }

  private bool IsPlayerInSight()
  {
    if(PlayerMovement.IsClingingToWall) return false;

    Vector2 boxCenter = (Vector2)transform.position + viewOffset;
    Collider2D playerCollider = Physics2D.OverlapBox(boxCenter, viewSize, currentAngle, playerLayer);
    return playerCollider != null;
  }


  void OnDrawGizmos()
  {
    Gizmos.color = Color.cyan;
    Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.Euler(0, 0, currentAngle), Vector3.one);
    Gizmos.DrawWireCube(Vector2.zero + viewOffset, viewSize);
    Gizmos.matrix = Matrix4x4.identity;
  }

  protected override void OnPlayerExit()
  {
    detectedPlayer = null;
    playerDetectionTimer = 0f;
  }

  protected override void OnPlayerDetected()
  {
    if(IsPlayerInSight())
    {
      if(detectedPlayer == null)
      {
        detectedPlayer = Physics2D.OverlapBox((Vector2)transform.position + viewOffset, viewSize, currentAngle, playerLayer);
        playerDetectionTimer = 0f;
      }

      playerDetectionTimer += Time.deltaTime;
      if(playerDetectionTimer >= 2f && !isResearchStep)
      {
        Debug.Log("2초 이상 감지됨");
        GameManager.GameOver();
      }
    }
    else detectedPlayer = null;
  }
}
