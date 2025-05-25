using UnityEngine;

public class SecurityGuardAnimationController : MonoBehaviour
{
  private Animator animator;
  private SecurityGuardBehavior securityGuardBehavior;

  private void Awake()
  {
    animator = GetComponent<Animator>();
    securityGuardBehavior = GetComponent<SecurityGuardBehavior>();
  }

  private void Update()
  {
    animator.SetBool("isRuning", true);
    if (securityGuardBehavior.isRuning) animator.speed = 2.0f;
    else animator.speed = 1.0f;

    if(securityGuardBehavior.isOver) animator.enabled = false;
  }
}
