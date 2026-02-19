// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardAssetLoader
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
