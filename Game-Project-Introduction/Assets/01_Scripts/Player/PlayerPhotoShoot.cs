using UnityEngine;

public class PlayerPhotoShoot : MonoBehaviour
{
  [Header("오브젝트 레이어")]
  public LayerMask PathLayer;
  public LayerMask targetLayer;

  [Header("사진 촬영 이펙트")]
  public PhotoShootEffect photoShootEffect;
  public GameObject displayPath;
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

    Collider2D[] pathFound = Detector.DetectAll(center, size, PathLayer);
    Collider2D[] targetFound = Detector.DetectAll(center, size, targetLayer);

    if(pathFound.Length > 0){
      foreach(var obj in pathFound){
        var detected = obj.GetComponent<DectectedObjectBase>();
        if(detected != null){
          detectedObjects.RegisterDetection(detected.objectType, detected.objectID);
          var displayImage = displayPath.GetComponent<DisplayImageUI>();
          displayImage.Display();
        }
      }
    }

    if(targetFound.Length > 0){
      foreach(var obj in targetFound){
        var detected = obj.GetComponent<DectectedObjectBase>();
        if (detected != null)
        {
          detectedObjects.RegisterDetection(detected.objectType, detected.objectID);
          var displayImage = displayTarget.GetComponent<DisplayImageUI>();
          displayImage.Display();
          Debug.Log(detected.objectType);
          Debug.Log(detected.objectID);
        }
      }
    }
  }
}
