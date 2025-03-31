using System;
using UnityEngine;

public class PlayerDebugger : MonoBehaviour
{
  public PlayerCollectClue playerCollectClue;

  private void Start()
  {

  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.cyan;
    Vector2 boxCenter = (Vector2)transform.position;
    Gizmos.DrawWireCube(boxCenter, playerCollectClue.boxSize);
  }
}
