using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// 사진 촬영이펙트
public class PhotoShootEffect : MonoBehaviour
{
  Image panelImage;

  private void Awake()
  {
    panelImage = GetComponent<Image>();
    panelImage.color = new Color(1, 1, 1, 0);
  }

  // 사진 촬영 이펙트
  public void PhotoShoot()
  {
    StartCoroutine(FlashEffect());
  }

  // 흰색으로 1초동안 점멸 코루틴
  private IEnumerator FlashEffect()
  {
    float duration = 1f;
    float timer = 0f;

    panelImage.color = new Color(1, 1, 1, 1);

    while(timer < duration)
    {
      // 알파 값을 1 -> 0
      timer += Time.deltaTime;
      float alpha = Mathf.Lerp(1f, 0f, timer / duration);
      panelImage.color = new Color(1, 1, 1, alpha);
      yield return null;
    }

    panelImage.color = new Color(1, 1, 1, 0);
  }
}
