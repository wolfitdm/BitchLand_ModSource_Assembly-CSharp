// Decompiled with JetBrains decompiler
// Type: ParticleSystemAutoDestroy
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
