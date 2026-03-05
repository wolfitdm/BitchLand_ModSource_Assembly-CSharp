// Decompiled with JetBrains decompiler
// Type: MapMagic.Nodes.MatrixGenerators.CTSOutput200
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
  [GeneratorMenu(menu = "Map/Output", name = "CTS", section = 2, drawButtons = false, colorType = typeof (MatrixWorld), iconName = "GeneratorIcons/TexturesOut", helpLink = "https://gitlab.com/denispahunov/mapmagic/wikis/output_generators/Textures")]
  [Serializable]
  public class CTSOutput200 : BaseTexturesOutput<CTSOutput200.CTSLayer>
  {
    public string[] guiTextureNames;
    public static FinalizeAction finalizeAction = new FinalizeAction(CTSOutput200.Finalize);

    public override void Generate(TileData data, StopToken stop)
    {
      MatrixWorld[] matrixWorldArray = this.BaseGenerate(data, stop);
      if (stop != null && stop.stop)
        return;
      if (this.enabled)
      {
        for (int index = 0; index < this.layers.Length; ++index)
          data.StoreOutput((IUnit) this.layers[index], (object) typeof (CTSOutput200), (object) this.layers[index], (object) matrixWorldArray[index]);
        data.MarkFinalize(new FinalizeAction(CTSOutput200.Finalize), stop);
      }
      else
        data.RemoveFinalize(CTSOutput200.finalizeAction);
    }

    public override FinalizeAction FinalizeAction => CTSOutput200.finalizeAction;

    public static void Finalize(TileData data, StopToken stop)
    {
    }

    public override void ClearApplied(TileData data, Terrain terrain)
    {
    }

    public class CTSLayer : BaseTextureLayer
    {
    }
  }
}
