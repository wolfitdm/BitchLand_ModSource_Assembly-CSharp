// Decompiled with JetBrains decompiler
// Type: bl_flipperscript
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
