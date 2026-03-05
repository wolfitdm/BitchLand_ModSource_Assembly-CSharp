// Decompiled with JetBrains decompiler
// Type: ChangingSignImages
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
