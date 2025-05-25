using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour
{
  public bool isNomal = false;

  private Animator animator;

  private void Awake()
  {
    animator = GetComponent<Animator>();
  }

  private void Update()
  {
    // 이동 중
    bool isMoving = Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0f;

    if (!isNomal)
    {
      if (isMoving)
      {
        if (PlayerMovement.IsClingingToWall)
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
    else
    {
      if (Input.GetKeyDown(KeyCode.C))
      {
        animator.SetBool("isCamera", true);
        StartCoroutine(ResetCameraBool());
      }

      if (isMoving)
      {
        animator.SetBool("isRuning", true);
      }
      else animator.SetBool("isRuning", false);
    }
  }
  
  private IEnumerator ResetCameraBool()
  {
    yield return null;
    animator.SetBool("isCamera", false);
  }
}
