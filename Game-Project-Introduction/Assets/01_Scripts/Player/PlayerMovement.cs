using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

// 플에이어 이동 (임시)
public class PlayerMovement : MonoBehaviour
{
  [Header("플레이어 스탯")]
  public SO_PlayerStat playerStats;

  private Rigidbody2D rb;
  private Vector2 moveDirection;

  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    moveDirection.x = Input.GetAxisRaw("Horizontal"); // A, D
    moveDirection.y = 0f;
  }

  private void FixedUpdate()
  {
    // 이동
    rb.linearVelocity = new Vector2(moveDirection.x * playerStats.moveSpeed, rb.linearVelocity.y);
  }
}
