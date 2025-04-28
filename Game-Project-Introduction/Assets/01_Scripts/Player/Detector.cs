using UnityEngine;

// 레이어 감지 유틸리티 클래스
public static class Detector
{
  public static Collider2D Detect(Vector2 origin, Vector2 boxSize, LayerMask layerMask)
  {
    return Physics2D.OverlapBox(origin, boxSize, 0f, layerMask);
  }

  public static Collider2D[] DetectAll(Vector2 origin, Vector2 boxSize, LayerMask layerMask)
  {
    return Physics2D.OverlapBoxAll(origin, boxSize, 0f, layerMask);
  }
}
