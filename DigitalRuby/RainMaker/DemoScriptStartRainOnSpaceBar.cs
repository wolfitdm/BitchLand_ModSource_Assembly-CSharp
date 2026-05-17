// Decompiled with JetBrains decompiler
// Type: DigitalRuby.RainMaker.DemoScriptStartRainOnSpaceBar
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace DigitalRuby.RainMaker
{
  public class DemoScriptStartRainOnSpaceBar : MonoBehaviour
  {
    public BaseRainScript RainScript;

    private void Start()
    {
      if ((Object) this.RainScript == (Object) null)
        return;
      this.RainScript.EnableWind = false;
    }

    private void Update()
    {
      if ((Object) this.RainScript == (Object) null || !Input.GetKeyDown(KeyCode.Space))
        return;
      this.RainScript.RainIntensity = (double) this.RainScript.RainIntensity == 0.0 ? 1f : 0.0f;
      this.RainScript.EnableWind = !this.RainScript.EnableWind;
    }
  }
}
