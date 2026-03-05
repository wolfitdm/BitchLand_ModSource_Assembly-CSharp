// Decompiled with JetBrains decompiler
// Type: SlowMotion
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
