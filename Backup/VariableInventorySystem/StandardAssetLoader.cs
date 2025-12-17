// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardAssetLoader
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;

#nullable disable
namespace VariableInventorySystem;

public class StandardAssetLoader
{
  public virtual IEnumerator LoadAsync(IVariableInventoryAsset imageAsset, Action<Texture2D> onLoad)
  {
    ResourceRequest loader = Resources.LoadAsync<Texture2D>((imageAsset as StandardAsset).Path);
    yield return (object) loader;
    onLoad(loader.asset as Texture2D);
  }
}
