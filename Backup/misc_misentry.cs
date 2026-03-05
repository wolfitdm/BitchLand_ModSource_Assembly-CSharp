// Decompiled with JetBrains decompiler
// Type: misc_misentry
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
