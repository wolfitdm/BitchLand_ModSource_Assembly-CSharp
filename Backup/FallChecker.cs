// Decompiled with JetBrains decompiler
// Type: FallChecker
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FallChecker : MonoBehaviour
{
  public Rigidbody rg;

  public void FixedUpdate()
  {
    if ((double) this.rg.transform.position.y >= -10000.0)
      return;
    this.rg.transform.position = new Vector3(0.0f, 0.2f, 0.0f);
    if (!((Object) this.rg != (Object) null))
      return;
    this.rg.velocity = Vector3.zero;
  }
}
