// Decompiled with JetBrains decompiler
// Type: SlowMotion
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
