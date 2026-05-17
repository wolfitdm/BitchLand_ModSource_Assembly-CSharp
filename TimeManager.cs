// Decompiled with JetBrains decompiler
// Type: TimeManager
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TimeManager : MonoBehaviour
{
  public float slowdownFactor = 0.05f;
  public float slowdownLength = 2f;
  private bool _isSlowMo;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Q))
      this._isSlowMo = !this._isSlowMo;
    if (this._isSlowMo)
      this.DoSlowMotion();
    else
      this.Reset();
  }

  private void DoSlowMotion()
  {
    Time.timeScale = this.slowdownFactor;
    Time.fixedDeltaTime = 0.02f * Time.timeScale;
  }

  private void Reset()
  {
    Time.timeScale += 1f / this.slowdownLength * Time.unscaledDeltaTime;
    Time.timeScale = Mathf.Clamp(Time.timeScale, 0.0f, 1f);
  }
}
