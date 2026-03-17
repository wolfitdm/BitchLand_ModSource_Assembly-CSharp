// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.MultilayerGroundTextureDef
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Peace.Serialization
{
  [Serializable]
  public class MultilayerGroundTextureDef : IGroundWorkerDef
  {
    public string type = "MultilayerGroundTexture";
    public uint distribResolution = 257;
    public bool generateTexture;
    public List<DistributionParams> layers = new List<DistributionParams>();
    public ITextureProviderDef texProvider = (ITextureProviderDef) new GroundTextureGeneratorDef();
  }
}
