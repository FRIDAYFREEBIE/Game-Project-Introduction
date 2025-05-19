using UnityEngine;

public class PlayerOpenDoor : PlayerDetectorBase
{
  protected override void OnDetected(Collider2D[] targets)
  {
    foreach(var target in targets)
    {
      var door = target.GetComponent<DoorDetectPlayer>();
      if(door != null)
      {
        door.PlayerOpenDoor(transform);
        Debug.Log("문 탐지");
      }
    }
  }
}
