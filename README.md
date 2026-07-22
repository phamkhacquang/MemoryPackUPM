# MemoryPack.Unity.UPM

A standalone Unity Package Manager package for [Cysharp MemoryPack](https://github.com/Cysharp/MemoryPack) that installs directly from Git without requiring NuGetForUnity or Visual Studio NuGet restore.

## Requirements

- Unity 2022.3 LTS or newer
- Unity 2022.3.12f1 or newer recommended for Roslyn source generator support
- IL2CPP-compatible targets such as Android and iOS

## Installation from Git URL

Add the package with one of these URLs:

```text
https://github.com/<owner>/MemoryPack.Unity.UPM.git
https://github.com/<owner>/MemoryPack.Unity.UPM.git#<tag>
```

For this repository, use:

```text
https://github.com/phamkhacquang/MemoryPackUPM.git
https://github.com/phamkhacquang/MemoryPackUPM.git#1.21.4
```

## Installation from Package Manager

1. Open **Window > Package Manager**.
2. Choose **+ > Add package from git URL...**.
3. Paste the repository URL.
4. Import the **Basic MemoryPack Usage** sample if you want working example scripts.

## Package Layout

- `Runtime/` contains the Unity-specific formatter registration code and runtime assembly definition.
- `Editor/Analyzers/` contains `MemoryPack.Generator.dll` so Unity can run the official source generator.
- `Plugins/` contains the bundled `MemoryPack.Core.dll` runtime and its required managed dependencies.
- `Tests/` contains package-scoped Unity tests.
- `Samples~/Basic/` contains sample scripts you can import into a project.

## Usage Example

```csharp
using MemoryPack;

[MemoryPackable]
public partial class SimpleData
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
```

## Serialization Example

```csharp
var data = new SimpleData
{
    Id = 1,
    Name = "MemoryPack"
};

byte[] bytes = MemoryPackSerializer.Serialize(data);
```

## Deserialization Example

```csharp
SimpleData? restored = MemoryPackSerializer.Deserialize<SimpleData>(bytes);
```

## Common Issues

### Source generator output is missing

- Confirm the project is on Unity 2022.3.12f1 or newer.
- Reimport the package if Unity imported the analyzer before compilation finished.
- Ensure your serializable types are marked with both `[MemoryPackable]` and `partial`.

### Assembly version validation warnings

If Unity reports assembly version validation issues, disable **Player Settings > Other Settings > Assembly Version Validation**.

### Android or iOS build verification

This package bundles the official MemoryPack runtime and generator artifacts that upstream documents as IL2CPP-compatible. You should still verify Android and iOS player builds in your own Unity CI or local build pipeline after importing the package into a clean project.

## Validation Checklist

After importing into a clean Unity project, verify:

- The package resolves directly from Git with no NuGetForUnity dependency.
- `[MemoryPackable]` types compile and generated formatters appear.
- Serialization and deserialization work in Edit Mode or Play Mode.
- IL2CPP builds succeed for Standalone, Android, and iOS targets.

## Upstream Source

This package vendors the official `MemoryPack.Core` and `MemoryPack.Generator` artifacts built from the upstream [Cysharp/MemoryPack](https://github.com/Cysharp/MemoryPack) repository at version `1.21.4`, plus the official Unity formatter sources from `src/MemoryPack.Unity`.
