// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Displacement.Turbulence
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise.Generation.Fractal;
using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Displacement;

public class Turbulence : Generator
{
  private readonly int m_Seed;
  private readonly Generator m_Source;
  private Generator m_DisplacementX;
  private Generator m_DisplacementY;
  private Generator m_DisplacementZ;
  private float m_Frequency;
  private int m_OctaveCount;

  public Turbulence(Generator source, int seed)
  {
    this.m_Source = source;
    this.m_Seed = seed;
    this.Power = 1f;
    this.Frequency = 1f;
    this.OctaveCount = 6;
  }

  public float Power { get; set; }

  public float Frequency
  {
    get => this.m_Frequency;
    set
    {
      this.m_Frequency = value;
      this.CreateDisplacementSource();
    }
  }

  public int OctaveCount
  {
    get => this.m_OctaveCount;
    set
    {
      this.m_OctaveCount = value;
      this.CreateDisplacementSource();
    }
  }

  public override float GetValue(float x, float y, float z)
  {
    Vector3 vector3 = new Vector3(this.m_DisplacementX.GetValue(x, y, z), this.m_DisplacementY.GetValue(x, y, z), this.m_DisplacementZ.GetValue(x, y, z)) * this.Power;
    return this.m_Source.GetValue(x + vector3.x, y + vector3.y, z + vector3.z);
  }

  private void CreateDisplacementSource()
  {
    PinkNoise pinkNoise1 = new PinkNoise(this.m_Seed);
    pinkNoise1.Frequency = this.Frequency;
    pinkNoise1.OctaveCount = this.OctaveCount;
    this.m_DisplacementX = (Generator) pinkNoise1;
    PinkNoise pinkNoise2 = new PinkNoise(this.m_Seed + 1);
    pinkNoise2.Frequency = this.Frequency;
    pinkNoise2.OctaveCount = this.OctaveCount;
    this.m_DisplacementY = (Generator) pinkNoise2;
    PinkNoise pinkNoise3 = new PinkNoise(this.m_Seed + 2);
    pinkNoise3.Frequency = this.Frequency;
    pinkNoise3.OctaveCount = this.OctaveCount;
    this.m_DisplacementZ = (Generator) pinkNoise3;
  }
}
