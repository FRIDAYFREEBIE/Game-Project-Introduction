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
    StartCoroutine(UseDoor(player));
  }

  private IEnumerator UseDoor(Transform player)
  {
    FadeControllerUI.Instance.FadeOut();
    yield return new WaitForSeconds(FadeControllerUI.Instance.fadeDuration);

    Vector3 pos = nextPos.position;
    pos.y -= 1f;
    player.position = pos;

    FadeControllerUI.Instance.FadeIn();
  }
}
