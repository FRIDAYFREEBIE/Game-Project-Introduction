using UnityEngine;

public class PlayerListenNPC : PlayerDetectorBase
{
  public DialogUI dialog;

  protected override void OnDetected(Collider2D[] targets)
  {
    foreach(var npc in targets)
    {
      var npcScript = npc.GetComponent<NPCScript>();
      if(npcScript != null)
      {
        dialog.SetText(npcScript.script);
      }
    }
  }
}
