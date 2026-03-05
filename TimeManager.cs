// Decompiled with JetBrains decompiler
// Type: TimeManager
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
