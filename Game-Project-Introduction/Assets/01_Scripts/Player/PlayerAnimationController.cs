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
      else
      {
        animator.SetBool("isRuning", false);
        animator.SetBool("isClinging", false);
      }
    }
    else
    {
      if (Input.GetKeyDown(KeyCode.C))
      {
        animator.SetBool("isCamera", true);
        StartCoroutine(ResetBool("isCamera"));
      }

      animator.SetBool("isRuning", isMoving);
    }
  }

  public void PlayTake()
  {
    animator.SetBool("isTake", true);
    StartCoroutine(ResetBool("isTake"));
  }

  public void PlaySurprise()
  {
    animator.SetBool("isSurprise", true);
    StartCoroutine(ResetBool("isSurprise"));
  }

  private IEnumerator ResetBool(string parameter)
  {
    yield return null;
    animator.SetBool(parameter, false);
  }
}
