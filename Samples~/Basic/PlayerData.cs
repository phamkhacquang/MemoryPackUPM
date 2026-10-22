using MemoryPack;
using UnityEngine;

[MemoryPackable]
public partial class PlayerData
{
    public string PlayerName { get; set; } = string.Empty;
    public int Score { get; set; }
    public Vector3 Position { get; set; }
}
