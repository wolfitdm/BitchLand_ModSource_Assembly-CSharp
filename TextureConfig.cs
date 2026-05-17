// Decompiled with JetBrains decompiler
// Type: TextureConfig
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class TextureConfig : IEquatable<TextureConfig>
{
  public Texture2D Diffuse;
  public Texture2D NormalMap;

  public override bool Equals(object other) => this.Equals(other as TextureConfig);

  public bool Equals(TextureConfig other)
  {
    return other != null && (UnityEngine.Object) other.Diffuse == (UnityEngine.Object) this.Diffuse && (UnityEngine.Object) other.NormalMap == (UnityEngine.Object) this.NormalMap;
  }

  public override int GetHashCode()
  {
    int hashCode = 17;
    if ((UnityEngine.Object) this.Diffuse != (UnityEngine.Object) null)
      hashCode = hashCode * 23 + this.Diffuse.GetHashCode();
    if ((UnityEngine.Object) this.NormalMap != (UnityEngine.Object) null)
      hashCode = hashCode * 23 + this.NormalMap.GetHashCode();
    return hashCode;
  }
}
