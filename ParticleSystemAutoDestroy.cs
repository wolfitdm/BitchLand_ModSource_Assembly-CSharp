// Decompiled with JetBrains decompiler
// Type: ParticleSystemAutoDestroy
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ParticleSystemAutoDestroy : MonoBehaviour
{
  public ParticleSystem ps;

  public void FixedUpdate()
  {
    if (!(bool) (Object) this.ps || this.ps.IsAlive())
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
