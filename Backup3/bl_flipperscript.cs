// Decompiled with JetBrains decompiler
// Type: bl_flipperscript
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_flipperscript : MonoBehaviour
{
  public GameObject[] Objs;
  public float TimerMax;
  public float Timer;

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer < (double) this.TimerMax)
      return;
    this.Timer = 0.0f;
    this.Objs[0].SetActive(!this.Objs[0].activeSelf);
    this.Objs[1].SetActive(!this.Objs[1].activeSelf);
  }
}
