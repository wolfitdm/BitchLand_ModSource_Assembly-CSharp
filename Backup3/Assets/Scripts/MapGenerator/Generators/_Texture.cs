// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.MapGenerator.Generators._Texture
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
