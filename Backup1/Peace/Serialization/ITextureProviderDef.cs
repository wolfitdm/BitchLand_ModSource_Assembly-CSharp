// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.ITextureProviderDef
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
