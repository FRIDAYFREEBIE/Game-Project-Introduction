using UnityEngine;

[CreateAssetMenu(fileName = "NewDetectedObjects", menuName = "Object/Detected")]
public class SO_DetectedObjects : ScriptableObject
{
  [Header("감지 상태")]
  public bool isEntry1Detected = false;
  public bool isEntry2Detected = false;
  public bool isEscapeDetected = false;
  public bool isClueDetected = false;

  public void RegisterDetection(ObjectType type, int id)
  {
    if(type == ObjectType.Entry)
    {
      if(id == 1) isEntry1Detected = true;
      else if(id == 2) isEntry2Detected = true;
    }
    else if(type == ObjectType.Escape) isEscapeDetected = true;
    else if(type == ObjectType.Clue) isClueDetected = true;
  }

  public bool IsDetected(ObjectType type, int id)
  {
    if(type == ObjectType.Entry)
    {
      if(id == 1) return isEntry1Detected;
      else if(id == 2) return isEntry2Detected;
    }
    else if(type == ObjectType.Escape) return isEscapeDetected;
    else if(type == ObjectType.Clue) return isClueDetected;

    return false;
  }
}
