using UnityEngine.UI;
using UnityEngine;

public class TableManager : MonoBehaviour
{
  [Header("감지")]
  public SO_DetectedObjects detectedObjects;

  [Header("경로")]
  public SO_SelectedPath selectedPath;

  [Header("UI")]
  public Image entry;
  public Image escape;
  public Image target;

  void Start()
  {
    if (detectedObjects.IsDetected(ObjectType.Path, 0)) entry.color = Color.green;
    else entry.color = Color.red;

    if (detectedObjects.IsDetected(ObjectType.Path, 1)) escape.color = Color.green;
    else escape.color = Color.red;

    if (detectedObjects.IsDetected(ObjectType.Target, 0)) target.color = Color.green;
    else target.color = Color.red;

    selectedPath.entryId = 0;
    selectedPath.escapeId = 1;
  }
}
