using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
  [Header("플레이어 스탯")]
  public SO_PlayerStat playerStats;

  public static bool IsClingingToWall { get; private set; }

  private Rigidbody2D rb;
  private Vector2 moveDirection;
  public bool isClingingToWall = false;
  private SpriteRenderer spriteRenderer;

  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  private void Update()
  {
    moveDirection.x = Input.GetAxisRaw("Horizontal");
  }

  private void FixedUpdate()
  {
    moveDirection.y = 0f;

    if (Input.GetKeyDown(KeyCode.X))
    {
      isClingingToWall = !isClingingToWall;
      IsClingingToWall = isClingingToWall;
      Debug.Log(IsClingingToWall);
    }

    float speed = playerStats.moveSpeed;
    if(isClingingToWall) speed *= 0.5f;

    Vector2 nextPosition = rb.position + new Vector2(moveDirection.x * speed * Time.fixedDeltaTime, 0f);
    rb.MovePosition(nextPosition);

    if(moveDirection.x != 0) spriteRenderer.flipX = moveDirection.x > 0;
  }
}
