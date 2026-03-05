// Decompiled with JetBrains decompiler
// Type: floatsafe
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
