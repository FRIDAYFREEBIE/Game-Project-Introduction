using UnityEngine.UI;
using UnityEngine;

public class TableManager : MonoBehaviour
{
  [Header("감지")]
  public SO_DetectedObjects detectedObjects;

  [Header("UI")]
  public Image entry;
  public Image escape;
  public Image target;

  void Start()
  {
    if(detectedObjects.IsDetected(ObjectType.Entry, 1)) entry.color = Color.green;
    else entry.color = Color.red;
  
    if(detectedObjects.IsDetected(ObjectType.Escape, 1)) escape.color = Color.green;
    else escape.color = Color.red;

    if(detectedObjects.IsDetected(ObjectType.Target, 1)) target.color = Color.green;
    else target.color = Color.red;
  }
}
