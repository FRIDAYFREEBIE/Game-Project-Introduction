using Unity.VisualScripting;
using UnityEngine;

public class PlayerOpenDoor : MonoBehaviour
{
  [Header("목표 탐지")]
  public LayerMask doorLayer;
  public Vector2 boxSize = new Vector2(1f, 1f);

  private void Update()
  {
    if(Input.GetKeyDown(KeyCode.F)){
      Vector2 boxCenter = (Vector2)transform.position;
      Collider2D target = Detector.Detect(boxCenter, boxSize, doorLayer);

      if (target != null)
      {
        DoorDetectPlayer doorDetectPlayer = target.gameObject.GetComponent<DoorDetectPlayer>();
        doorDetectPlayer.PlayerOpenDoor(transform);
      }
    }
  }
}
