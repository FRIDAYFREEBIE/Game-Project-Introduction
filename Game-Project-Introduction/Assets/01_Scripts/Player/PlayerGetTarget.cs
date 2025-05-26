using UnityEngine;

public class PlayerGetTarget : PlayerDetectorBase
{
  protected override void OnDetected(Collider2D[] targets)
  {
    if (targets.Length > 0)
    {
      GameManager.GetTarget();

      var anim = GetComponent<PlayerAnimationController>();
      if (anim != null)
      {
        anim.PlayTake();
      }
    }
  }
}
