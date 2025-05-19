using UnityEngine;

[System.Serializable]
public class DetectionSettings
{
  [Tooltip("플레이어 레이어")]
  public LayerMask playerLayer;

  [Tooltip("감지 박스 크기")]
  public Vector2 size = new Vector2(3f, 1f);

  [Tooltip("박스 위치 오프셋")]
  public Vector2 offset = new Vector2(2.24f, 0f);
}