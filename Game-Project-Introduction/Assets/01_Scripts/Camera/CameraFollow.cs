using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  [Header("플레이어")]
  public Transform target;

  [Header("카메라 세팅")]
  public float followSpeed = 7f;
  public float offsetY = 0f;

  private void LateUpdate()
  {
    Vector3 targetPosition = new Vector3(target.position.x, target.position.y + offsetY, -10f);
    transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
  }
}
