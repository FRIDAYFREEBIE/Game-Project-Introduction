using System;
using UnityEngine;

public class PlayerDebugger : MonoBehaviour
{
  public PlayerMovement playerMovement;

  private void Start()
  {
    if(playerMovement == null) playerMovement = GetComponent<PlayerMovement>();
  }

  private void OnDrawGizmos()
  {
    if(playerMovement.groundCheck == null) return;

    Gizmos.color = Color.red;

    Gizmos.DrawWireCube(playerMovement.groundCheck.position, playerMovement.groundCheckSize);
  }
}
