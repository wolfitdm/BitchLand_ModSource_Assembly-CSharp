// Decompiled with JetBrains decompiler
// Type: intsafe
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
