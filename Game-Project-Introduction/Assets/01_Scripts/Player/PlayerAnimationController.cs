using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
  private Animator animator;
  private Rigidbody2D rb;

  private void Awake()
  {
    animator = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    // 이동 중
    bool isMoving = Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0f;

    if (isMoving)
    {
      if(PlayerMovement.IsClingingToWall)
      {
        animator.SetBool("isClinging", true);
        animator.SetBool("isRuning", false);
      }
      else
      {
        animator.SetBool("isRuning", true);
        animator.SetBool("isClinging", false);
      }
    }
    else animator.SetBool("isRuning", false);
  }
}
