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
  private bool isWaiting = false;

  public Collider2D detectedPlayer;
  private float detectionTimer = 0f;

  protected override void Update()
  {
    base.Update();
    HandleRotation();
    HandleDetectionTimer();
  }

  private void HandleRotation()
  {
    if(isWaiting)
    {
      waitTimer += Time.deltaTime;
      if(waitTimer >= waitTimeAtAngle) isWaiting = false;
      return;
    }

    currentAngle += (rotatingToPositive ? 1f : -1f) * rotationSpeed * Time.deltaTime;

    if(currentAngle >= maxAngle)
    {
      currentAngle = maxAngle;
      StartWaiting();
    }
    else if(currentAngle <= -maxAngle)
    {
      currentAngle = -maxAngle;
      StartWaiting();
    }

    transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
  }

  private void StartWaiting()
  {
    isWaiting = true;
    waitTimer = 0f;
    rotatingToPositive = !rotatingToPositive;
  }

  private void HandleDetectionTimer()
  {
    if(player != null && IsInDetectionArea(player.transform.position))
    {
      if(detectedPlayer == null)
      {
        detectedPlayer = player;
        detectionTimer = 0f;
      }

      detectionTimer += Time.deltaTime;

      if(detectionTimer >= 2f)
      {
        if(!isResearchStep)
        {
          Debug.Log("감지");
          GameManager.GameOver();
        }
        else Debug.Log("감지, 조사 단계");
      }
    }
    else
    {
      detectedPlayer = null;
      detectionTimer = 0f;
    }
  }

  private bool IsInDetectionArea(Vector2 position)
  {
    Quaternion rotation = Quaternion.Euler(0f, 0f, currentAngle - 90f);
    Vector2 rotatedOffset = rotation * detection.offset;
    Vector2 center = (Vector2)transform.position + rotatedOffset;

    Collider2D hit = Physics2D.OverlapBox(center, detection.size, currentAngle - 90f, detection.playerLayer);

    if(hit != null && hit.transform == player.transform)
    {
      return true;
    }

    return false;
  }

  private void OnDrawGizmos()
  {
    Quaternion rotation = Quaternion.Euler(0f, 0f, currentAngle - 90f);
    Vector2 rotatedOffset = rotation * detection.offset;
    Vector2 center = (Vector2)transform.position + rotatedOffset;

    Gizmos.color = Color.cyan;
    Gizmos.matrix = Matrix4x4.TRS(center, rotation, Vector3.one);
    Gizmos.DrawWireCube(Vector2.zero, detection.size);
    Gizmos.matrix = Matrix4x4.identity;
  }

  protected override void OnPlayerDetected() { }

  protected override void OnPlayerExit()
  {
    detectedPlayer = null;
    detectionTimer = 0f;
  }
}
