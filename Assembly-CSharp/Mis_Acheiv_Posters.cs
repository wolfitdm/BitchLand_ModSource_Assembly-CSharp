// Decompiled with JetBrains decompiler
// Type: Mis_Acheiv_Posters
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class Mis_Acheiv_Posters : MonoBehaviour
{
  public Text AcheiveText;
  public Text AcheiveText2;
  public Text AcheiveText3;
  public Text AcheiveText4;
  public GameObject AcheivCheck;
  public GameObject AcheivCheck2;
  public GameObject AcheivCheck3;
  public GameObject AcheivCheck4;

  public void UpdateAcheiv1()
  {
    int num = 0;
    for (int index = 0; index < Main.Instance.GameplayMenu.HasPostersBC.Length; ++index)
    {
      if (Main.Instance.GameplayMenu.HasPostersBC[index])
        ++num;
    }
    this.AcheiveText.text = "Found All Bitch Commando Posters " + num.ToString() + "/" + Main.Instance.GameplayMenu.HasPostersBC.Length.ToString();
    if (num == Main.Instance.GameplayMenu.HasPostersBC.Length)
      this.AcheivCheck.SetActive(true);
    Main.Instance.GameplayMenu.DisplayGoalSimple(this.AcheiveText.text, this.AcheivCheck.activeSelf);
  }

  public void UpdateAcheiv2()
  {
    int num = 0;
    for (int index = 0; index < Main.Instance.GameplayMenu.HasPostersBCLeg.Length; ++index)
    {
      if (Main.Instance.GameplayMenu.HasPostersBCLeg[index])
        ++num;
    }
    this.AcheiveText.text = "Found All Bitch Commando Posters Legacy " + num.ToString() + "/" + Main.Instance.GameplayMenu.HasPostersBCLeg.Length.ToString();
    if (num == Main.Instance.GameplayMenu.HasPostersBCLeg.Length)
      this.AcheivCheck.SetActive(true);
    Main.Instance.GameplayMenu.DisplayGoalSimple(this.AcheiveText.text, this.AcheivCheck.activeSelf);
  }

  public void UpdateAcheiv3()
  {
    int num = 0;
    for (int index = 0; index < Main.Instance.GameplayMenu.HasPostersBCBEL.Length; ++index)
    {
      if (Main.Instance.GameplayMenu.HasPostersBCBEL[index])
        ++num;
    }
    this.AcheiveText.text = "Found All BC Behind Enemy Lines Posters " + num.ToString() + "/" + Main.Instance.GameplayMenu.HasPostersBCBEL.Length.ToString();
    if (num == Main.Instance.GameplayMenu.HasPostersBCBEL.Length)
      this.AcheivCheck.SetActive(true);
    Main.Instance.GameplayMenu.DisplayGoalSimple(this.AcheiveText.text, this.AcheivCheck.activeSelf);
  }

  public void UpdateAcheiv4()
  {
    int num = 0;
    for (int index = 0; index < Main.Instance.GameplayMenu.HasPostersBCCap.Length; ++index)
    {
      if (Main.Instance.GameplayMenu.HasPostersBCCap[index])
        ++num;
    }
    this.AcheiveText.text = "Found All Bitch Commando Captured Posters " + num.ToString() + "/" + Main.Instance.GameplayMenu.HasPostersBCCap.Length.ToString();
    if (num == Main.Instance.GameplayMenu.HasPostersBCCap.Length)
      this.AcheivCheck.SetActive(true);
    Main.Instance.GameplayMenu.DisplayGoalSimple(this.AcheiveText.text, this.AcheivCheck.activeSelf);
  }
}
