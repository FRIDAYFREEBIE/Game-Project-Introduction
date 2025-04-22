using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGetTarget : MonoBehaviour
{
  [Header("단계 표시")]
  public bool isResearchStep = true;

  [Header("목표 탐지")]
  public LayerMask clueLayer;  
  public Vector2 boxSize = new Vector2(0f, 0f);

  [Header("타이머")]
  public TimerManager timerManager;

  private void Update()
  {
    if(Input.GetKeyDown(KeyCode.F)){
      Vector2 boxCenter = (Vector2)transform.position;

      Collider2D target = Physics2D.OverlapBox(boxCenter, boxSize, 0f, clueLayer);

      if(target != null && !isResearchStep && timerManager != null){
        if(timerManager.isClear()) Debug.Log("클리어");
        else Debug.Log("클리어 실패");
      }
      else if(target != null && isResearchStep) SceneManager.LoadScene("TableScene");
    }
  }
}
