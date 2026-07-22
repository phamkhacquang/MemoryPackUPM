using MemoryPack;

[MemoryPackable]
public partial class SimpleData
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
