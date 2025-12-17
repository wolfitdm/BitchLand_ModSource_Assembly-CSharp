// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.CellCorner
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace VariableInventorySystem;

public enum CellCorner
{
  None = 0,
  Top = 2,
  Bottom = 4,
  Left = 8,
  TopLeft = 10, // 0x0000000A
  BottomLeft = 12, // 0x0000000C
  Right = 16, // 0x00000010
  TopRight = 18, // 0x00000012
  BottomRight = 20, // 0x00000014
}
