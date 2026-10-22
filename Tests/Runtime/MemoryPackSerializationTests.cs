using MemoryPack;
using NUnit.Framework;
using UnityEngine;

namespace MemoryPack.Tests
{
    [MemoryPackable]
    public partial class MemoryPackPlayerSnapshot
    {
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public Vector3 Position { get; set; }
    }

    public class MemoryPackSerializationTests
    {
        [Test]
        public void SerializeAndDeserialize_MemoryPackableType_RoundTripsUnityData()
        {
            var original = new MemoryPackPlayerSnapshot
            {
                Name = "Hero",
                Level = 12,
                Position = new Vector3(1.5f, 2.5f, 3.5f)
            };

            var bytes = MemoryPackSerializer.Serialize(original);
            var restored = MemoryPackSerializer.Deserialize<MemoryPackPlayerSnapshot>(bytes);

            Assert.That(restored, Is.Not.Null);
            Assert.That(restored!.Name, Is.EqualTo(original.Name));
            Assert.That(restored.Level, Is.EqualTo(original.Level));
            Assert.That(restored.Position, Is.EqualTo(original.Position));
        }
    }
}
