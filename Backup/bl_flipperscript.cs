// Decompiled with JetBrains decompiler
// Type: bl_flipperscript
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
