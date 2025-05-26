using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogUI : MonoBehaviour
{
  [Header("UI 오브젝트")]
  public GameObject dialogPanel;

  [Header("플레이어 말풍선")]
  public GameObject playerBubble;
  public TextMeshProUGUI playerText;

  [Header("NPC 말풍선")]
  public GameObject npcBubble;
  public TextMeshProUGUI npcText;

  private int currentIndex = 0;
  private bool isPlaying = false;
  private List<DialogueLine> currentScript;

  public void SetText(List<DialogueLine> script)
  {
    currentScript = script;
    currentIndex = 0;
    isPlaying = true;

    dialogPanel.SetActive(true);
    ShowCurrentLine();
  }

  private void Update()
  {
    if (isPlaying && Input.GetKeyDown(KeyCode.Space))
    {
      currentIndex++;

      if (currentIndex < currentScript.Count)
      {
        ShowCurrentLine();
      }
      else
      {
        EndDialog();
      }
    }
  }

  private void ShowCurrentLine()
  {
    DialogueLine line = currentScript[currentIndex];

    if (line.speaker == Speaker.Player)
    {
      playerBubble.SetActive(true);
      npcBubble.SetActive(false);
      playerText.text = line.text;
    }
    else
    {
      npcBubble.SetActive(true);
      playerBubble.SetActive(false);
      npcText.text = line.text;
    }
  }

  private void EndDialog()
  {
    isPlaying = false;
    dialogPanel.SetActive(false);
    playerBubble.SetActive(false);
    npcBubble.SetActive(false);
  }
}
