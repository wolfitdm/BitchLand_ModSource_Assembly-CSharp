// Decompiled with JetBrains decompiler
// Type: SlowMotion
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
