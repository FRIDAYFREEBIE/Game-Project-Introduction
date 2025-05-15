using UnityEngine;

public class PlayerPhotoShoot : MonoBehaviour
{
  [Header("오브젝트 레이어")]
  public LayerMask entryLocationLayer;
  public LayerMask escapeLocationLayer;
  public LayerMask targetLayer;

  [Header("사진 촬영 이펙트")]
  public PhotoShootEffect photoShootEffect;
  public GameObject displayEntryLocation;
  public GameObject displayEscapeLocation;
  public GameObject displayTarget;

  [Header("오브젝트 감지")]
  public SO_DetectedObjects detectedObjects;

  private float shootCooldown = 2f;
  private float lastShootTime = -999f;
  private Camera mainCam;

  private void Start()
  {
    mainCam = Camera.main;
  }

  private void Update()
  {
    // 사진 촬영
    if(Input.GetKeyDown(KeyCode.C) && Time.time - lastShootTime >= shootCooldown){
      photoShootEffect.PhotoShoot();
      PhotoShoot();
      lastShootTime = Time.time;
    }
  }

  private void PhotoShoot()
  {
    Vector2 bottomLeft = mainCam.ViewportToWorldPoint(new Vector3(0, 0, mainCam.nearClipPlane));
    Vector2 topRight = mainCam.ViewportToWorldPoint(new Vector3(1, 1, mainCam.nearClipPlane));

    Vector2 center = (bottomLeft + topRight) * 0.5f;
    Vector2 size = topRight - bottomLeft;

    Collider2D[] entryFound = Detector.DetectAll(center, size, entryLocationLayer);
    Collider2D[] escapeFound = Detector.DetectAll(center, size, escapeLocationLayer);
    Collider2D[] targetFound = Detector.DetectAll(center, size, targetLayer);

    if(entryFound.Length > 0){
      foreach(var obj in entryFound){
        var detected = obj.GetComponent<DectectedObjectBase>();
        if(detected != null){
          detectedObjects.RegisterDetection(detected.objectType, detected.objectID);
          var displayImage = displayEntryLocation.GetComponent<DisplayImageUI>();
          displayImage.Display();
        }
      }
    }

    if(escapeFound.Length > 0){
      foreach(var obj in escapeFound){
        var detected = obj.GetComponent<DectectedObjectBase>();
        if(detected != null){
          detectedObjects.RegisterDetection(detected.objectType, detected.objectID);
          var displayImage = displayEscapeLocation.GetComponent<DisplayImageUI>();
          displayImage.Display();
        }
      }
    }

    if(targetFound.Length > 0){
      foreach(var obj in targetFound){
        var detected = obj.GetComponent<DectectedObjectBase>();
        if(detected != null){
          detectedObjects.RegisterDetection(detected.objectType, detected.objectID);
          var displayImage = displayTarget.GetComponent<DisplayImageUI>();
          displayImage.Display();
        }
      }
    }
  }
}
