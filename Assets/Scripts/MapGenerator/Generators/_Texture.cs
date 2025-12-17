// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.MapGenerator.Generators._Texture
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Assets.Scripts.MapGenerator.Generators;

public class _Texture
{
  public Vector2 Tilesize = new Vector2(1f, 1f);
  public AnimationCurve HeightCurve = AnimationCurve.Linear(0.0f, 1f, 1f, 1f);
  public AnimationCurve AngleCurve = AnimationCurve.Linear(0.0f, 1f, 1f, 1f);

  public Texture2D Texture { get; set; }

  public Color Color { get; set; }

  public int Type { get; set; }
}
