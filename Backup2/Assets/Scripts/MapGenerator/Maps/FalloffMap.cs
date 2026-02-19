// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.MapGenerator.Maps.FalloffMap
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Assets.Scripts.MapGenerator.Abstract;
using UnityEngine;

#nullable disable
namespace Assets.Scripts.MapGenerator.Maps;

public class FalloffMap : IMap
{
  public float FalloffDirection;
  public float FalloffRange;
  public int Size;

  public float[,] Generate()
  {
    float[,] numArray = new float[this.Size, this.Size];
    for (int index1 = 0; index1 < this.Size; ++index1)
    {
      for (int index2 = 0; index2 < this.Size; ++index2)
      {
        double f1 = (double) index1 / (double) this.Size * 2.0 - 1.0;
        float f2 = (float) ((double) index2 / (double) this.Size * 2.0 - 1.0);
        float num = Mathf.Max(Mathf.Abs((float) f1), Mathf.Abs(f2));
        numArray[index1, index2] = this.Evaluate(num);
      }
    }
    return numArray;
  }

  private float Evaluate(float value)
  {
    return Mathf.Pow(value, this.FalloffDirection) / (Mathf.Pow(value, this.FalloffDirection) + Mathf.Pow(this.FalloffRange - this.FalloffRange * value, this.FalloffDirection));
  }
}
