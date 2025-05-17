using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorDetectPlayer : PlayerDetectorBase
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
    player.transform.position = nextPos.position;
  }
}
