// Decompiled with JetBrains decompiler
// Type: bl_Temp_onChunkSpawn
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
