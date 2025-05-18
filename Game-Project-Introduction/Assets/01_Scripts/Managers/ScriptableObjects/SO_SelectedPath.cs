using UnityEngine;

public enum PathType
{
  Entry,
  Escape
}

[CreateAssetMenu(fileName = "NewPathObjects", menuName = "Path/Selected")]
public class SO_SelectedPath : ScriptableObject
{
  public int entryId = -1;
  public int escapeId = -1;

  public void SetPath(PathType pathType ,int id)
  {
    if(pathType == PathType.Entry) entryId = id;
    else escapeId = id;
  }
}
