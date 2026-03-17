// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.ITextureProviderDef
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
