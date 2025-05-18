using UnityEngine;
using UnityEngine.UI;

public class ImageSliderUI : MonoBehaviour
{
  [Header("이미지 리스트")]
  public Sprite[] imageList;

  [Header("UI 참조")]
  public Image imageDisplay;

  [Header("경로 선택")]
  public PathType pathType;
  public SO_SelectedPath selectedPath;

  private int currentIndex = 0;

  void Start()
  {
    ShowImage(currentIndex);
    selectedPath.SetPath(pathType, currentIndex);
  }

  public void ShowNext()
  {
    if(imageList.Length == 0) return;
    currentIndex = (currentIndex + 1) % imageList.Length;
    ShowImage(currentIndex);
    selectedPath.SetPath(pathType, currentIndex);
  }

  public void ShowPrevious()
  {
    if(imageList.Length == 0) return;
    currentIndex = (currentIndex - 1 + imageList.Length) % imageList.Length;
    ShowImage(currentIndex);
    selectedPath.SetPath(pathType, currentIndex);
  }

  private void ShowImage(int index)
  {
    imageDisplay.sprite = imageList[index];
  }

  public int GetCurrentIndex()
  {
    return currentIndex;
  }
}
