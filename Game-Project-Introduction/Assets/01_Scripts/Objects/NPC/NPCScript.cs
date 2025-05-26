using System.Collections.Generic;
using UnityEngine;

public enum Speaker
{
  Player,
  NPC
}

[System.Serializable]
public class DialogueLine
{
  public Speaker speaker;
  public string text;
}

public class NPCScript : MonoBehaviour
{
  public List<DialogueLine> script = new List<DialogueLine>();
}
