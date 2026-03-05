// Decompiled with JetBrains decompiler
// Type: DigitalRuby.RainMaker.DemoScriptStartRainOnSpaceBar
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
