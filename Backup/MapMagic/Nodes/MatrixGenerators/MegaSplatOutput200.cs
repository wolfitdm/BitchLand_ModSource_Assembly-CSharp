// Decompiled with JetBrains decompiler
// Type: MapMagic.Nodes.MatrixGenerators.MegaSplatOutput200
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Den.Tools.Matrices;
using MapMagic.Products;
using System;
using UnityEngine;

#nullable disable
namespace MapMagic.Nodes.MatrixGenerators;

[GeneratorMenu(menu = "Map/Output", name = "MegaSplat", section = 2, drawButtons = false, colorType = typeof (MatrixWorld), iconName = "GeneratorIcons/TexturesOut", helpLink = "https://gitlab.com/denispahunov/mapmagic/wikis/output_generators/Textures")]
[Serializable]
public class MegaSplatOutput200 : BaseTexturesOutput<MegaSplatOutput200.MegaSplatLayer>
{
  public static float clusterNoiseScale = 0.05f;
  private string[] clusterNames = new string[0];
  public static bool smoothFallof = false;
  public static FinalizeAction finalizeAction = new FinalizeAction(MegaSplatOutput200.Finalize);

  public override void Generate(TileData data, StopToken stop)
  {
    MatrixWorld[] matrixWorldArray = this.BaseGenerate(data, stop);
    if (stop != null && stop.stop)
      return;
    if (this.enabled)
    {
      for (int index = 0; index < this.layers.Length; ++index)
        data.StoreOutput((IUnit) this.layers[index], (object) typeof (MegaSplatOutput200), (object) this.layers[index], (object) matrixWorldArray[index]);
      data.MarkFinalize(new FinalizeAction(MegaSplatOutput200.Finalize), stop);
    }
    else
      data.RemoveFinalize(MegaSplatOutput200.finalizeAction);
  }

  public override FinalizeAction FinalizeAction => MegaSplatOutput200.finalizeAction;

  public static void Finalize(TileData data, StopToken stop)
  {
  }

  public override void ClearApplied(TileData data, Terrain terrain)
  {
  }

  public class MegaSplatLayer : BaseTextureLayer
  {
  }
}
