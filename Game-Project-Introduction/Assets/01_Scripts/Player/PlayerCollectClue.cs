using UnityEngine;

public class PlayerCollectClue : MonoBehaviour
{
  [Header("단서 탐지")]
  public LayerMask clueLayer;  
  public Vector2 boxSize = new Vector2(0f, 0f);
  public GameObject displayClue;

  [Header("오브젝트 감지")]
  public SO_DetectedObjects detectedObjects;

  private void Update()
  {
    if(Input.GetKeyDown(KeyCode.F)){
      Vector2 boxCenter = (Vector2)transform.position;

      Collider2D[] clues = Physics2D.OverlapBoxAll(boxCenter, boxSize, 0f, clueLayer);

      if(clues.Length > 0){
        foreach(var clue in clues){
          Debug.Log("단서 발견 " + clue.name);
          DectectedObjectBase dectectedObjectBase = clue.GetComponent<DectectedObjectBase>();
          detectedObjects.RegisterDetection(dectectedObjectBase.objectType,dectectedObjectBase.objectID);
          DisplayImageUI displayImage = displayClue.GetComponent<DisplayImageUI>();
          displayImage.Display();
        }
      }
    }
  }
}
