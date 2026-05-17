// Decompiled with JetBrains decompiler
// Type: SlowMotion
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SlowMotion : MonoBehaviour
{
  public bool enableSloMo = true;

  private void Update()
  {
    if (!this.enableSloMo)
      return;
    Time.timeScale = !Input.GetKey(KeyCode.Q) ? 1f : 0.25f;
    Time.fixedDeltaTime = 0.02f * Time.timeScale;
  }
}
