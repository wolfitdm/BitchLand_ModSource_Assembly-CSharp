// Decompiled with JetBrains decompiler
// Type: ChangingSignImages
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
