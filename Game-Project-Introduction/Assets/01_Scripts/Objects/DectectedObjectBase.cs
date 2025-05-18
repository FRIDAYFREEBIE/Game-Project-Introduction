using System.IO;
using UnityEngine;

public enum ObjectType
{
  Path,
  Clue,
  Target
}

public class DectectedObjectBase : MonoBehaviour
{
  [Header("오브젝트 정보")]
  public ObjectType objectType = ObjectType.Path;
  public int objectID = 0;
}
