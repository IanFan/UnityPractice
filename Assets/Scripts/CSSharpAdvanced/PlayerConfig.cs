using UnityEngine;

[CreateAssetMenu(
    fileName = "PlayerConfig",
    menuName = "Game/Player Config"
)]
public class PlayerConfig : ScriptableObject
{
    public int maxHp = 100;
    public float moveSpeed = 5;
}