using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("플레이어")]
    public Transform target;

    [Header("카메라 이동 속도")]
    public float followSpeed = 7f;

    private void LateUpdate()
    {
      Vector3 targetPosition = new Vector3(target.position.x, target.position.y, -10f);
      transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
