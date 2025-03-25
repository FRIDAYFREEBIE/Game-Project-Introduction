using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

// 플에이어 이동 (임시)
public class PlayerMovement : MonoBehaviour
{
  [Header("플레이어 스탯")]
  public SO_PlayerStat playerStats;

  [Header("플레이어 점프")]
  public Transform groundCheck; // 땅 체크 위치
  public LayerMask groundLayer; // 땅 레이어
  public Vector2 groundCheckSize = new Vector2(0.5f, 0.1f); // 감지 박스 크기

  private Rigidbody2D rb;
  private Vector2 moveDirection;
  private bool isGrounded;  // 땅에 닿았는지 판단

  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    moveDirection.x = Input.GetAxisRaw("Horizontal"); // A, D
    moveDirection.y = 0f;

    // 점프
    if(Input.GetKeyDown(KeyCode.Space) && isGrounded) jump();

    isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer);
  }

  private void FixedUpdate()
  {
    // 이동
    rb.linearVelocity = new Vector2(moveDirection.x * playerStats.moveSpeed, rb.linearVelocity.y);
  }

  // 점프
  private void jump()
  {
    rb.linearVelocity = new Vector2(rb.linearVelocity.x, playerStats.jumpForce);
  }
}
