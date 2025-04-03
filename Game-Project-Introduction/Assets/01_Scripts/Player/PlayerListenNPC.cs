using UnityEngine;

public class PlayerListenNPC : MonoBehaviour
{
  [Header("NPC 탐지")]
  public LayerMask NPCLayer;  
  public Vector2 boxSize = new Vector2(0f, 0f);
  public Dialog dialog;

  private void Update()
  {
    if(Input.GetKeyDown(KeyCode.F)){
      Vector2 boxCenter = (Vector2)transform.position;

      Collider2D npc = Physics2D.OverlapBox(boxCenter, boxSize, 0f, NPCLayer);

      if(npc != null) dialog.SetText(npc.GetComponent<NPCScript>().script);
    }
  }
}
