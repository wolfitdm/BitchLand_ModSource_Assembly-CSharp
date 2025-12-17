// Decompiled with JetBrains decompiler
// Type: intsafe
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
