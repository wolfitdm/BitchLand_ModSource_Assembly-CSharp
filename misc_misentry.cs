// Decompiled with JetBrains decompiler
// Type: misc_misentry
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
