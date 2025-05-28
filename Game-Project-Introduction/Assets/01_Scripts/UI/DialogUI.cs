using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogUI : MonoBehaviour
{
  [Header("UI 오브젝트")]
  public GameObject dialogPanel;
  public GameObject dialogBackground;

  [Header("플레이어 말풍선")]
  public GameObject playerBubble;
  public TextMeshProUGUI playerText;

  [Header("NPC 말풍선")]
  public GameObject npcBubble;
  public TextMeshProUGUI npcText;

  [Header("미스테리 말풍선")]
  public GameObject mysteryBubble;
  public TextMeshProUGUI mysteryText;

  private int currentIndex = 0;
  private bool isPlaying = false;
  private List<DialogueLine> currentScript;

  void Start()
  {
    dialogBackground.SetActive(false);
  }

  public void SetText(List<DialogueLine> script)
  {
    currentScript = script;
    currentIndex = 0;
    isPlaying = true;

    dialogPanel.SetActive(true);
    dialogBackground.SetActive(true);
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
      npcBubble.SetActive(false);
      playerBubble.SetActive(true);
      mysteryBubble.SetActive(false);
      playerText.text = line.text;
    }
    else if (line.speaker == Speaker.NPC)
    {
      npcBubble.SetActive(true);
      playerBubble.SetActive(false);
      mysteryBubble.SetActive(false);
      npcText.text = line.text;
    }
    else if (line.speaker == Speaker.Mystery)
    {
      npcBubble.SetActive(false);
      playerBubble.SetActive(false);
      mysteryBubble.SetActive(true);
      mysteryText.text = line.text;
    }
  }

  private void EndDialog()
  {
    isPlaying = false;
    dialogPanel.SetActive(false);
    dialogBackground.SetActive(false);
    playerBubble.SetActive(false);
    npcBubble.SetActive(false);
  }
}
