using UnityEngine;

public enum ObjectType
{
  Entry,
  Escape,
  Clue
}

public class DectectedObjectBase : MonoBehaviour
{
  [Header("오브젝트 정보")]
  public ObjectType objectType;
  public int objectID = 0;
}
