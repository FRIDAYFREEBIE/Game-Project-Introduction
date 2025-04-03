using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
  [Header("텍스트")]
  public TextMeshProUGUI textMeshPro;
  public GameObject dialog;

  public List<string> text;
  int currentLine = 0;

  void Update()
  {
    if(dialog.activeSelf && Input.GetKeyDown(KeyCode.Return)) NextLine();
  }

  // 대화 설정
  public void SetText(List<string> list)
  {
    text = list;
    currentLine = 0;

    dialog.SetActive(true);

    textMeshPro.text = text[currentLine];
  }

  public void NextLine()
  {
    Debug.Log("NextLine");


    if(currentLine < text.Count - 1){
      currentLine++;
      textMeshPro.text = text[currentLine];
      Debug.Log(text[currentLine]);
    }
    else dialog.SetActive(false);
  }
}
