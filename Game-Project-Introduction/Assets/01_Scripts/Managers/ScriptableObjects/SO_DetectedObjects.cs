using UnityEngine;

[CreateAssetMenu(fileName = "NewDetectedObjects", menuName = "Object/Detected")]
public class SO_DetectedObjects : ScriptableObject
{
  [Header("감지 상태")]
  public bool isPath1Detected = false;
  public bool isPath2Detected = false;
  public bool isTargetDetected = false;

  public void RegisterDetection(ObjectType type, int id)
  {
    if(type == ObjectType.Target && id == 0) isTargetDetected = true;
    if(type == ObjectType.Path && id == 0) isPath1Detected = true;
    if(type == ObjectType.Path && id == 1) isPath2Detected = true;
  }

  public bool IsDetected(ObjectType type, int id)
  {
    if(type == ObjectType.Target && id == 0) return isTargetDetected;
    if(type == ObjectType.Path && id == 0) return isPath1Detected;
    if(type == ObjectType.Path && id == 1) return isPath2Detected;

    return false;
  }
}
