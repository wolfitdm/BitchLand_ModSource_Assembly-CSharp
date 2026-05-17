// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardAssetLoader
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;

#nullable disable
namespace VariableInventorySystem
{
  public class StandardAssetLoader
  {
    public virtual IEnumerator LoadAsync(
      IVariableInventoryAsset imageAsset,
      Action<Texture2D> onLoad)
    {
      ResourceRequest loader = Resources.LoadAsync<Texture2D>((imageAsset as StandardAsset).Path);
      yield return (object) loader;
      onLoad(loader.asset as Texture2D);
    }
  }
}
