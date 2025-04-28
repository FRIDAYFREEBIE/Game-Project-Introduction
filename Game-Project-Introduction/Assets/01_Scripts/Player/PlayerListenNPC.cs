using UnityEngine;

public class PlayerListenNPC : MonoBehaviour
{
  [Header("NPC 탐지")]
  public LayerMask npcLayer;
  public Vector2 boxSize = new Vector2(1f, 1f);
  public DialogUI dialog;

  private void Update()
  {
    // 대화 듣기
    if(Input.GetKeyDown(KeyCode.F)){
      Vector2 boxCenter = (Vector2)transform.position;
      Collider2D npc = Detector.Detect(boxCenter, boxSize, npcLayer);

      if(npc != null){
        var npcScript = npc.GetComponent<NPCScript>();
        if(npcScript != null){
          dialog.SetText(npcScript.script);
        }
      }
    }
  }
}