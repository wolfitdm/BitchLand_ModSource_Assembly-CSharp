// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.ITextureProviderDef
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Peace.Serialization
{
  [Serializable]
  public class ITextureProviderDef
  {
    public string type;
    public int texWidth = 256;
    public List<ShaderDef> layers = new List<ShaderDef>();
    public List<Color4dDef> colors = new List<Color4dDef>();
  }
}
