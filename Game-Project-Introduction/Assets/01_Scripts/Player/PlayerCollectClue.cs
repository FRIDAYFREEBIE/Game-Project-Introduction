using UnityEngine;

public class PlayerCollectClue : PlayerDetectorBase
{
  public GameObject displayClue;
  public SO_DetectedObjects detectedObjects;

  protected override void OnDetected(Collider2D[] targets)
  {
    foreach(var clue in targets)
    {
      var detected = clue.GetComponent<DectectedObjectBase>();
      if(detected != null)
      {
        detectedObjects.RegisterDetection(detected.objectType, detected.objectID);
        displayClue?.GetComponent<DisplayImageUI>()?.Display();
      }
    }
  }
}
