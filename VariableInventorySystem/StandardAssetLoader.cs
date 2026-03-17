// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardAssetLoader
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
