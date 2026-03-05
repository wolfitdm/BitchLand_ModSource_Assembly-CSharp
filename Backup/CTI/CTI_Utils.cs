// Decompiled with JetBrains decompiler
// Type: CTI.CTI_Utils
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace CTI
{
  public static class CTI_Utils
  {
    public static void SetTranslucentLightingFade(
      float TranslucentLightingRange,
      float FadeLengthFactor)
    {
      TranslucentLightingRange *= 0.9f;
      float num = TranslucentLightingRange * FadeLengthFactor;
      Shader.SetGlobalVector("_CTI_TransFade", (Vector4) new Vector2(TranslucentLightingRange * TranslucentLightingRange, (float) ((double) num * (double) num * ((double) TranslucentLightingRange / (double) num * 2.0))));
    }
  }
}
