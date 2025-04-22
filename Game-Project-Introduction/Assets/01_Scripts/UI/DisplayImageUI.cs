using UnityEngine;
using System.Collections;
using TMPro;

public class DisplayImageUI : MonoBehaviour
{
  [Header("표시 이미지")]
  public GameObject imageObject;

  [Header("표시 시간")]
  public float duration = 1f;

  private void Awake()
  {
    imageObject.SetActive(false);
  }

  // duration 만큼 표시
  public void Display()
  {
    StopAllCoroutines();
    StartCoroutine(ShowAndHide());
  }

  private IEnumerator ShowAndHide()
  {
    imageObject.SetActive(true);
    yield return new WaitForSeconds(duration);
    imageObject.SetActive(false);
  }
}
