using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGetTarget : MonoBehaviour
{
  [Header("단계 표시")]
  public bool isResearchStep = true;

  [Header("목표 탐지")]
  public LayerMask clueLayer;
  public Vector2 boxSize = new Vector2(1f, 1f);

  [Header("타이머")]
  public TimerManager timerManager;

  private void Update()
  {
    // 목표물 수집
    if(Input.GetKeyDown(KeyCode.F)){
      Vector2 boxCenter = (Vector2)transform.position;
      Collider2D target = Detector.Detect(boxCenter, boxSize, clueLayer);

      if(target != null){
        if(isResearchStep) SceneManager.LoadScene("TableScene");
        else if(timerManager != null){
          if(timerManager.isClear()) Debug.Log("클리어 성공");
          else Debug.Log("클리어 실패");
        }
      }
    }
  }
}