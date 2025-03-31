using UnityEngine;

public class ClueDetectPlayer : MonoBehaviour
{
  [Header("플레이어 탐지")]
  public LayerMask playerLayer;
  public Vector2 boxSize = new Vector2(0f, 0f);
  public GameObject button;

  Vector2 boxCenter;

  private void Start()
  {
    boxCenter = (Vector2)transform.position;
  }

  private void Update()
  {
    Collider2D player = Physics2D.OverlapBox(boxCenter, boxSize, 0f, playerLayer);
    if(player != null) button.SetActive(true);
    else button.SetActive(false);
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.cyan;
    Vector2 boxCenter = (Vector2)transform.position;
    Gizmos.DrawWireCube(boxCenter, boxSize);
  }
}
