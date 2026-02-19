// Decompiled with JetBrains decompiler
// Type: SignChangeMaterials
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
