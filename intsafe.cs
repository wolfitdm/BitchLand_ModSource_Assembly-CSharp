// Decompiled with JetBrains decompiler
// Type: intsafe
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
[Serializable]
public class intsafe
{
  public int _myFloat_safer;
  public int _myFloat;

  public int Value
  {
    get
    {
      if (this._myFloat_safer != Main.Instance.SafeIVal)
      {
        this._myFloat -= this._myFloat_safer;
        this._myFloat_safer = Main.Instance.SafeIVal;
        this._myFloat += this._myFloat_safer;
      }
      return this._myFloat - Main.Instance.SafeIVal;
    }
    set
    {
      if (this._myFloat_safer != Main.Instance.SafeIVal)
        this._myFloat_safer = Main.Instance.SafeIVal;
      this._myFloat = value + Main.Instance.SafeIVal;
    }
  }
}
