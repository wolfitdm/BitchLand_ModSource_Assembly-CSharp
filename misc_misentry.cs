// Decompiled with JetBrains decompiler
// Type: misc_misentry
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class misc_misentry : MonoBehaviour
{
  public Text Title;
  public GameObject Check;
  public GameObject Fail;
  public Mission ThisMis;
  public int ThisMiss;
  public string UncensoredText;

  public void Click()
  {
    Main.Instance.GameplayMenu.Journal_ShowGoal(Main.Instance.AllMissions[this.ThisMiss]);
  }
}
