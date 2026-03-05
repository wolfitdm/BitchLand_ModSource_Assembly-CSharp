// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardAssetLoader
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
