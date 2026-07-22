using MemoryPack;
using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    [ContextMenu("Run MemoryPack Example")]
    public void RunExample()
    {
        var player = new PlayerData
        {
            PlayerName = "Player One",
            Score = 9001,
            Position = new Vector3(2f, 4f, 6f)
        };

        byte[] serialized = MemoryPackSerializer.Serialize(player);
        PlayerData? deserialized = MemoryPackSerializer.Deserialize<PlayerData>(serialized);

        Debug.Log($"Serialized {player.PlayerName} into {serialized.Length} bytes.");
        Debug.Log($"Restored position: {deserialized?.Position}");
    }
}
