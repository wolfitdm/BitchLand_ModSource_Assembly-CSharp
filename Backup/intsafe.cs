// Decompiled with JetBrains decompiler
// Type: intsafe
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
