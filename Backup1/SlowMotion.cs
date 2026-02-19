// Decompiled with JetBrains decompiler
// Type: SlowMotion
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
