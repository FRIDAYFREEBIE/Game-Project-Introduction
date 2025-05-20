using UnityEngine;
using System.Collections;

public class DoorDetectPlayer : ObjectDetectorBase
{
  [Header("표시 이미지")]
  public GameObject button;

  [Header("이동 위치")]
  public Transform nextPos;

  protected override void OnPlayerDetected()
  {
    button.SetActive(true);
  }

  protected override void OnPlayerExit()
  {
    button.SetActive(false);
  }

  public void PlayerOpenDoor(Transform player)
  {
    StartCoroutine(UseDoor());
  }

  private IEnumerator UseDoor()
  {
    FadeControllerUI.Instance.FadeOut();
    yield return new WaitForSeconds(FadeControllerUI.Instance.fadeDuration);
    FadeControllerUI.Instance.FadeIn();
    player.transform.position = nextPos.position;
  }
}
