// Decompiled with JetBrains decompiler
// Type: Terra.Terrain.Detail.DetailManager
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Terra.Terrain.Detail;

public class DetailManager
{
  private TerrainTile Tile;

  public TerrainPaint Paint { get; private set; }

  public static ObjectRenderer ObjectPlacer { get; private set; }

  public DetailManager(TerrainTile tt)
  {
    this.Tile = tt;
    if (DetailManager.ObjectPlacer != null)
      return;
    DetailManager.ObjectPlacer = new ObjectRenderer();
  }

  public void Update() => GrassRenderer.Update();

  public TerrainPaint ApplySplatmap()
  {
    TerraEvent.TriggerOnSplatmapWillCalculate(this.Tile.gameObject);
    if (this.Paint == null)
      this.Paint = new TerrainPaint(this.Tile.gameObject);
    this.Paint.GenerateSplatmaps().ForEach((Action<Texture2D>) (m => TerraEvent.TriggerOnSplatmapDidCalculate(this.Tile.gameObject, m)));
    return this.Paint;
  }
}
