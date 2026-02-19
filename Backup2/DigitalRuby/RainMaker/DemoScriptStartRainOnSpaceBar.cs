// Decompiled with JetBrains decompiler
// Type: DigitalRuby.RainMaker.DemoScriptStartRainOnSpaceBar
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace DigitalRuby.RainMaker;

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
