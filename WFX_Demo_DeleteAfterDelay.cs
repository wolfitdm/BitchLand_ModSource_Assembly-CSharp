// Decompiled with JetBrains decompiler
// Type: WFX_Demo_DeleteAfterDelay
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class WFX_Demo_DeleteAfterDelay : MonoBehaviour
{
  public float delay = 1f;

  private void Update()
  {
    this.delay -= Time.deltaTime;
    if ((double) this.delay >= 0.0)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
