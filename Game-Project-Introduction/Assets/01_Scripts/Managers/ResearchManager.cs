using UnityEngine;
using UnityEngine.SceneManagement;

public class ResearchManager : MonoBehaviour
{
  [Header("이동할 씬 이름")]
  public string sceneName;

  [Header("플레이어 정지 판정")]
  public Transform playerTransform;
  public float positionThreshold = 0.1f;
  public float requiredTime = 3f;

  private float stillTimer = 0f;
  private Vector2 lastPosition;

  void Start()
  {
    if(playerTransform == null){
      GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
      if(playerObj != null) playerTransform = playerObj.transform;
    }

    if(playerTransform != null) lastPosition = playerTransform.position;
  }

  void Update()
  {
    if(playerTransform == null) return;

    float distance = Vector2.Distance(lastPosition, playerTransform.position);

    if(distance <= positionThreshold){
      stillTimer += Time.deltaTime;

      if(stillTimer >= requiredTime){
        Debug.Log("조사 종료");
        SceneManager.LoadScene(sceneName);
        stillTimer = 0f;
      }
    }
    else{
      stillTimer = 0f;
      lastPosition = playerTransform.position;
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if(other.CompareTag("Player")) SceneManager.LoadScene(sceneName);
  }
}
