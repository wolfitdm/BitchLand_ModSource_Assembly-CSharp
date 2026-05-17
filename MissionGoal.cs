// Decompiled with JetBrains decompiler
// Type: MissionGoal
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
