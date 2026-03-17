// Decompiled with JetBrains decompiler
// Type: misc_misentry
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
