// Decompiled with JetBrains decompiler
// Type: CTI.CTI_Utils
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
