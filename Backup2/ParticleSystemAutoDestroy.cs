// Decompiled with JetBrains decompiler
// Type: ParticleSystemAutoDestroy
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
