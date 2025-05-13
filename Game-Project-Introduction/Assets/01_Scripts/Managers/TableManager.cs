using UnityEngine.UI;
using UnityEngine;

public class TableManager : MonoBehaviour
{
  [Header("감지")]
  public SO_DetectedObjects detectedObjects;

  [Header("UI")]
  public Image entry1;
  public Image escape;

  void Start()
  {
    if(detectedObjects.IsDetected(ObjectType.Entry, 1)) entry1.color = Color.green;
    else entry1.color = Color.red;
  
    if(detectedObjects.IsDetected(ObjectType.Escape, 1)) escape.color = Color.green;
    else escape.color = Color.red;
  }
}
