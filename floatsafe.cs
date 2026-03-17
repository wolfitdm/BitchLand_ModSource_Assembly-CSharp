// Decompiled with JetBrains decompiler
// Type: floatsafe
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
