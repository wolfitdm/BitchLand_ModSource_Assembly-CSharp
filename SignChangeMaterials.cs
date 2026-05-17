// Decompiled with JetBrains decompiler
// Type: SignChangeMaterials
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SignChangeMaterials : MonoBehaviour
{
  public Renderer Ren;
  public int CurremntMat;
  public int[] Mats;
  public float Timer;
  public float TimerMax = 2f;

  public void Update()
  {
    this.Timer -= Time.deltaTime;
    if ((double) this.Timer > 0.0)
      return;
    this.Timer = this.TimerMax;
    this.Ren.materials[this.Mats[this.CurremntMat]].DisableKeyword("_EMISSION");
    if (++this.CurremntMat >= this.Mats.Length)
      this.CurremntMat = 0;
    this.Ren.materials[this.Mats[this.CurremntMat]].EnableKeyword("_EMISSION");
  }

  public void OnDisable()
  {
    for (int index = 0; index < this.Ren.materials.Length; ++index)
      this.Ren.materials[index].DisableKeyword("_EMISSION");
  }
}
