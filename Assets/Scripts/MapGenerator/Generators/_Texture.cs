// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.MapGenerator.Generators._Texture
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Assets.Scripts.MapGenerator.Generators
{
  public class _Texture
  {
    public Vector2 Tilesize = new Vector2(1f, 1f);
    public AnimationCurve HeightCurve = AnimationCurve.Linear(0.0f, 1f, 1f, 1f);
    public AnimationCurve AngleCurve = AnimationCurve.Linear(0.0f, 1f, 1f, 1f);

    public Texture2D Texture { get; set; }

    public Color Color { get; set; }

    public int Type { get; set; }
  }
}
