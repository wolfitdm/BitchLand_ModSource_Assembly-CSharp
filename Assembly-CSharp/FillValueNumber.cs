// Decompiled with JetBrains decompiler
// Type: FillValueNumber
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class FillValueNumber : MonoBehaviour
{
  public Image TargetImage;

  private void Update()
  {
    float num = this.TargetImage.fillAmount * 100f;
    this.gameObject.GetComponent<Text>().text = num.ToString("F0");
  }
}
