using UnityEngine;

[CreateAssetMenu(fileName = "NewDetectedObjects", menuName = "Object/Detected")]
public class SO_DetectedObjects : ScriptableObject
{
  [Header("감지 상태")]
  public bool isEntryDetected = false;
  public bool isEscapeDetected = false;
  public bool isTargetDetected = false;

  public void RegisterDetection(ObjectType type, int id)
  {
    if(type == ObjectType.Entry) isEntryDetected = true;
    else if(type == ObjectType.Escape) isEscapeDetected = true;
    else if(type == ObjectType.Target) isTargetDetected = true;
  }

  public bool IsDetected(ObjectType type, int id)
  {
    if(type == ObjectType.Entry) return isEntryDetected;
    else if(type == ObjectType.Escape) return isEscapeDetected;
    else if(type == ObjectType.Target) return isTargetDetected;

    return false;
  }
}
