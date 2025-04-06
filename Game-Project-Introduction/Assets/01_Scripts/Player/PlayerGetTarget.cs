using UnityEngine;

public class PlayerGetTarget : MonoBehaviour
{
  [Header("목표 탐지")]
  public LayerMask clueLayer;  
  public Vector2 boxSize = new Vector2(0f, 0f);

  private void Update()
  {
    if(Input.GetKeyDown(KeyCode.F)){
      Vector2 boxCenter = (Vector2)transform.position;

      Collider2D target = Physics2D.OverlapBox(boxCenter, boxSize, 0f, clueLayer);

      if(target != null){
        Debug.Log("클리어");
      }
    }
  }
}
