// Decompiled with JetBrains decompiler
// Type: MapMagic.Nodes.MatrixGenerators.RTPOutput200
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Den.Tools.Matrices;
using MapMagic.Products;
using System;
using UnityEngine;

#nullable disable
namespace MapMagic.Nodes.MatrixGenerators
{
  [GeneratorMenu(menu = "Map/Output", name = "RTP", section = 2, drawButtons = false, colorType = typeof (MatrixWorld), iconName = "GeneratorIcons/TexturesOut", helpLink = "https://gitlab.com/denispahunov/mapmagic/wikis/output_generators/Textures")]
  [Serializable]
  public class RTPOutput200 : BaseTexturesOutput<RTPOutput200.RTPLayer>
  {
    public static FinalizeAction finalizeAction = new FinalizeAction(RTPOutput200.Finalize);

    public override void Generate(TileData data, StopToken stop)
    {
      MatrixWorld[] matrixWorldArray = this.BaseGenerate(data, stop);
      if (stop != null && stop.stop)
        return;
      if (this.enabled)
      {
        for (int index = 0; index < this.layers.Length; ++index)
          data.StoreOutput((IUnit) this.layers[index], (object) typeof (RTPOutput200), (object) this.layers[index], (object) matrixWorldArray[index]);
        data.MarkFinalize(new FinalizeAction(RTPOutput200.Finalize), stop);
      }
      else
        data.RemoveFinalize(RTPOutput200.finalizeAction);
    }

    public override FinalizeAction FinalizeAction => RTPOutput200.finalizeAction;

    public static void Finalize(TileData data, StopToken stop)
    {
      if (data.OutputsCount((object) typeof (RTPOutput200), true) == 0)
      {
        if (stop != null && stop.stop)
          return;
        data.MarkApply((IApplyData) CustomShaderOutput200.ApplyData.Empty);
      }
      else
      {
        Color[][] colorArray = (Color[][]) null;
        if (stop != null && stop.stop)
          return;
        CustomShaderOutput200.ApplyData data1 = new CustomShaderOutput200.ApplyData()
        {
          textureColors = colorArray,
          textureFormat = TextureFormat.RGBA32,
          textureBaseMapDistance = 1E+07f,
          textureNames = new string[colorArray != null ? colorArray.Length : 0]
        };
        for (int index = 0; index < data1.textureNames.Length; ++index)
          data1.textureNames[index] = "_Control" + (index + 1).ToString();
        Action<System.Type, TileData, IApplyData, StopToken> onOutputFinalized = Graph.OnOutputFinalized;
        if (onOutputFinalized != null)
          onOutputFinalized(typeof (RTPOutput200), data, (IApplyData) data1, stop);
        data.MarkApply((IApplyData) data1);
      }
    }

    public override void ClearApplied(TileData data, Terrain terrain)
    {
    }

    public class RTPLayer : BaseTextureLayer
    {
    }
  }
}
