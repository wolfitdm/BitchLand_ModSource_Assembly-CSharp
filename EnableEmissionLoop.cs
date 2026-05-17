// Decompiled with JetBrains decompiler
// Type: EnableEmissionLoop
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class EnableEmissionLoop : MonoBehaviour
{
  public Renderer[] renderers;
  public float stepTime = 0.5f;
  public int currentIndex;
  public bool increasing = true;
  public float Timer;

  public void Update()
  {
    if (this.increasing)
      this.renderers[this.currentIndex].material.EnableKeyword("_EMISSION");
    else
      this.renderers[this.currentIndex].material.DisableKeyword("_EMISSION");
    this.Timer -= Time.deltaTime;
    if ((double) this.Timer >= 0.0)
      return;
    this.Timer = this.stepTime;
    if (this.increasing)
    {
      ++this.currentIndex;
      if (this.currentIndex != this.renderers.Length)
        return;
      this.increasing = false;
      this.currentIndex = 0;
    }
    else
    {
      ++this.currentIndex;
      if (this.currentIndex != this.renderers.Length)
        return;
      this.increasing = true;
      this.currentIndex = 0;
    }
  }
}
