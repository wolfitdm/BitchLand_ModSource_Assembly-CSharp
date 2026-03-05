// Decompiled with JetBrains decompiler
// Type: ChangingSignImages
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ChangingSignImages : MonoBehaviour
{
  public Renderer ThisRen;
  public int ThisMat;
  public float Timer;
  public float TimerMax = 5f;

  public void Start()
  {
    this.ThisRen.materials[this.ThisMat].mainTexture = Main.Instance.NeonSignsTextures[Random.Range(0, Main.Instance.NeonSignsTextures.Length)];
  }

  private void Update()
  {
    this.Timer -= Time.deltaTime;
    if ((double) this.Timer > 0.0)
      return;
    this.Timer = this.TimerMax + Random.Range(0.0f, this.TimerMax);
    this.ThisRen.materials[this.ThisMat].mainTexture = Main.Instance.NeonSignsTextures[Random.Range(0, Main.Instance.NeonSignsTextures.Length)];
  }
}
