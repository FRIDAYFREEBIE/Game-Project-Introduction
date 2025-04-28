using UnityEngine;

public class PlayerCollectClue : MonoBehaviour
{
  [Header("단서 탐지")]
  public LayerMask clueLayer;
  public Vector2 boxSize = new Vector2(1f, 1f);
  public GameObject displayClue;

  [Header("오브젝트 감지")]
  public SO_DetectedObjects detectedObjects;

  private void Update()
  {
    if(Input.GetKeyDown(KeyCode.F)){
      Vector2 boxCenter = (Vector2)transform.position;
      Collider2D[] clues = Detector.DetectAll(boxCenter, boxSize, clueLayer);

      if(clues.Length > 0){
        foreach(var clue in clues){
          var detected = clue.GetComponent<DectectedObjectBase>();
          if(detected != null){
            detectedObjects.RegisterDetection(detected.objectType, detected.objectID);
            var displayImage = displayClue.GetComponent<DisplayImageUI>();
            displayImage.Display();
          }
        }
      }
    }
  }
}
