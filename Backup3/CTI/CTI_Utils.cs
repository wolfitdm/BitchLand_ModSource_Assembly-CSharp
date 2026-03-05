// Decompiled with JetBrains decompiler
// Type: CTI.CTI_Utils
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
