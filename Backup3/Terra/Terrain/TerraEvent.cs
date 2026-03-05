// Decompiled with JetBrains decompiler
// Type: Terra.Terrain.TerraEvent
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Terra.Terrain
{
  public class TerraEvent
  {
    public static event TerraEvent.Action OnMeshWillForm;

    public static event TerraEvent.MeshColliderAction OnMeshColliderDidForm;

    public static event TerraEvent.Action OnSplatmapWillCalculate;

    public static event TerraEvent.SplatAction OnSplatmapDidCalculate;

    public static event TerraEvent.Action OnCustomMaterialWillApply;

    public static event TerraEvent.Action OnCustomMaterialDidApply;

    public static event TerraEvent.TileEvent OnTileDeactivated;

    public static event TerraEvent.TileEvent OnTileActivated;

    public static void TriggerOnMeshWillForm(GameObject go)
    {
      if (TerraEvent.OnMeshWillForm == null)
        return;
      TerraEvent.OnMeshWillForm(go);
    }

    public static void TriggerOnMeshColliderDidForm(GameObject go, MeshCollider collider)
    {
      if (TerraEvent.OnMeshColliderDidForm == null)
        return;
      TerraEvent.OnMeshColliderDidForm(go, collider);
    }

    public static void TriggerOnSplatmapWillCalculate(GameObject go)
    {
      if (TerraEvent.OnSplatmapWillCalculate == null)
        return;
      TerraEvent.OnSplatmapWillCalculate(go);
    }

    public static void TriggerOnSplatmapDidCalculate(GameObject go, Texture2D splat)
    {
      if (TerraEvent.OnSplatmapDidCalculate == null)
        return;
      TerraEvent.OnSplatmapDidCalculate(go, splat);
    }

    public static void TriggerOnCustomMaterialWillApply(GameObject go)
    {
      if (TerraEvent.OnCustomMaterialWillApply == null)
        return;
      TerraEvent.OnCustomMaterialWillApply(go);
    }

    public static void TriggerOnCustomMaterialDidApply(GameObject go)
    {
      if (TerraEvent.OnCustomMaterialDidApply == null)
        return;
      TerraEvent.OnCustomMaterialDidApply(go);
    }

    public static void TriggerOnTileDeactivated(TerrainTile tile)
    {
      if (TerraEvent.OnTileDeactivated == null)
        return;
      TerraEvent.OnTileDeactivated(tile);
    }

    public static void TriggerOnTileActivated(TerrainTile tile)
    {
      if (TerraEvent.OnTileActivated == null)
        return;
      TerraEvent.OnTileActivated(tile);
    }

    public delegate void Action(GameObject go);

    public delegate void MeshAction(GameObject go, Mesh mesh);

    public delegate void MeshColliderAction(GameObject go, MeshCollider meshCollider);

    public delegate void SplatAction(GameObject go, Texture2D splat);

    public delegate void TileEvent(TerrainTile tile);
  }
}
