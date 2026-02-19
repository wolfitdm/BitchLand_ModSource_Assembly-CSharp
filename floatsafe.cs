// Decompiled with JetBrains decompiler
// Type: floatsafe
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
[Serializable]
public class floatsafe
{
  public float _myFloat_safer;
  public float _myFloat;

  public float Value
  {
    get
    {
      if ((double) this._myFloat_safer != (double) Main.Instance.SafeFVal)
      {
        this._myFloat -= this._myFloat_safer;
        this._myFloat_safer = Main.Instance.SafeFVal;
        this._myFloat += this._myFloat_safer;
      }
      return this._myFloat - Main.Instance.SafeFVal;
    }
    set
    {
      if ((double) this._myFloat_safer != (double) Main.Instance.SafeFVal)
        this._myFloat_safer = Main.Instance.SafeFVal;
      this._myFloat = value + Main.Instance.SafeFVal;
    }
  }
}
