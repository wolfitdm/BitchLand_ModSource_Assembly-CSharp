// Decompiled with JetBrains decompiler
// Type: SignChangeMaterials
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
