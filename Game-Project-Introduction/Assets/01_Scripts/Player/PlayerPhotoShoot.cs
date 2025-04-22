using UnityEngine;

// 진입 위치 및 탈출 위치 사진 촬영
public class PlayerPhotoShoot : MonoBehaviour
{
  [Header("진입/탈출 위치 레이어")]
  public LayerMask entryLocationLayer;   // 진입 위치 레이어 마스크
  public LayerMask escapeLocationLayer;  // 탈출 위치 레이어 마스크

  [Header("사진 촬영 이펙트")]
  public PhotoShootEffect photoShootEffect; // 사진 촬영 이펙트
  public GameObject DisplayEntryLocation;   // 진입 위치 표시 UI
  public GameObject DisplayEscapeLocation;  // 탈출 위치 표시 UI

  float shootCooldown = 2f; // 사진 촬영 쿨타임
  float lastShootTime = -999f;
  Camera mainCam;

  private void Start()
  {
    mainCam = Camera.main;
  }

  private void Update()
  {
    // C키를 눌러 사진 촬영
    if(Input.GetKeyDown(KeyCode.C) && Time.time - lastShootTime >= shootCooldown){
      photoShootEffect.PhotoShoot();
      PhotoShoot();
      lastShootTime = Time.time;
    }
  }

  // 사진 촬영
  private void PhotoShoot()
  {
    Vector2 bottomLeft = mainCam.ViewportToWorldPoint(new Vector3(0, 0, mainCam.nearClipPlane));
    Vector2 topRight = mainCam.ViewportToWorldPoint(new Vector3(1, 1, mainCam.nearClipPlane));

    Collider2D[] entryFound = Physics2D.OverlapAreaAll(bottomLeft, topRight, entryLocationLayer);
    Collider2D[] escapeFound = Physics2D.OverlapAreaAll(bottomLeft, topRight, escapeLocationLayer);

    // 진입 위치
    if(entryFound.Length > 0){
      foreach(var obj in entryFound){
        Debug.Log("진입 위치 촬영 " + obj.name);
        DisplayImageUI displayImage = DisplayEntryLocation.GetComponent<DisplayImageUI>();
        displayImage.Display();
      }
    }

    // 탈출 위치
    if(escapeFound.Length > 0){
      foreach(var obj in escapeFound){
        Debug.Log("탈출 위치 촬영 " + obj.name);
        DisplayImageUI displayImage = DisplayEscapeLocation.GetComponent<DisplayImageUI>();
        displayImage.Display();
      }
    }
  }
}
