// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.ShaderDef
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Peace.Serialization
{
  [Serializable]
  public class ShaderDef
  {
    public string fragmentPath;
    public List<ShaderParam> @params = new List<ShaderParam>();

    public ShaderDef(string fragmentPath = "", IEnumerable<ShaderParam> pparams = null)
    {
      this.fragmentPath = fragmentPath;
      if (pparams == null)
        return;
      this.@params.AddRange(pparams);
    }
  }
}
