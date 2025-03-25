using UnityEngine;

// 플레이어 스탯 스크립터블 오브젝트입니다.
// 해당 스크립터블 오브젝트를 인스펙터에서 값을 조정하시면 됩니다.
[CreateAssetMenu(fileName = "NewPlayerStat", menuName = "Player/Stat")]
public class SO_PlayerStat : ScriptableObject
{
   public float moveSpeed = 5f;   // 이동 속도
   public float jumpForce = 10f;  // 점프력  
}