// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.MultilayerGroundTextureDef
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
