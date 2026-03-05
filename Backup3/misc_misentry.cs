// Decompiled with JetBrains decompiler
// Type: misc_misentry
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
