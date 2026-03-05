// Decompiled with JetBrains decompiler
// Type: MissionGoal
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
