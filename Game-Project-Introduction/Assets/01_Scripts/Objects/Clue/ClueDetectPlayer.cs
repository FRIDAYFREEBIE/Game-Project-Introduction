using UnityEngine;

public class ClueDetectPlayer : ObjectDetectorBase
{
  [Header("표시 이미지")]
  public GameObject button;

  protected override void OnPlayerDetected()
  {
    button.SetActive(true);
  }

  protected override void OnPlayerExit()
  {
    button.SetActive(false);
  }
}
