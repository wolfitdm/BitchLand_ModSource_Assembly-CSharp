// Decompiled with JetBrains decompiler
// Type: MissionGoal
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
[Serializable]
public class MissionGoal
{
  public string Title;
  public bool Completed;
  public bool Failed;
  public int Index;
  public int ItemQuantity;
  public int ItemQuantityMax;

  public bool isNull() => this.Title.Length == 0;
}
