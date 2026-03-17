// Decompiled with JetBrains decompiler
// Type: bl_Temp_onChunkSpawn
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class bl_Temp_onChunkSpawn : MonoBehaviour
{
  public List<Transform> _Unatatch;

  public virtual void OnChunkSpawn()
  {
    for (int index = 0; index < this._Unatatch.Count; ++index)
      this._Unatatch[index].SetParent((Transform) null, true);
  }
}
