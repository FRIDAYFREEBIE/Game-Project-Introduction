using UnityEngine;

public class DisplaySettingUI : MonoBehaviour
{
  [Header("설정 창")]
  public GameObject settingObject;

  void Update()
  {
    if(Input.GetKeyDown(KeyCode.Escape)) ToggleSetting();
  }

  public void ToggleSetting()
  {
    if(settingObject != null)
    {
      bool isActive = settingObject.activeSelf;
      settingObject.SetActive(!isActive);
    }
  }
}
