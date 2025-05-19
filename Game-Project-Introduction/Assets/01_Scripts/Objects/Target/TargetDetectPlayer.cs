using UnityEngine;

public class TargetDetectPlayer : ObjectDetectorBase
{
  [Header("표시 이미지")]
  public GameObject button;

  protected override void OnPlayerDetected()
  {
    if(!isResearchStep) button.SetActive(true);
  }

  protected override void OnPlayerExit()
  {
    if(!isResearchStep) button.SetActive(false);
  }
}
