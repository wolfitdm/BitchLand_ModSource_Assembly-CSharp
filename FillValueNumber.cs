// Decompiled with JetBrains decompiler
// Type: FillValueNumber
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
